import { randomUUID } from 'node:crypto';
import { chats } from '../data/chats.ts';
import { ChatBody } from '../schemas/chat.ts';
import { client } from '../services/claude.ts';
import type { RequestHandler } from 'express';
import z from 'zod';
import { betaZodOutputFormat } from '@anthropic-ai/sdk/helpers/beta/zod.mjs';

// ---------- Chat mit History ----------

const chatHandler: RequestHandler = async (req, res) => {
  // console.log(req.body['prompt']);
  // Body prüfen. Ist er ungültig, wirft parse() einen ZodError -> errorHandler antwortet mit 400.
  const { prompt, chatId } = ChatBody.parse(req.body);

  // Chatverlauf? Neuer Chat -> leerer Verlauf, bestehender Chat -> gespeicherte Messages
  const history = chatId ? chats.get(chatId) : [];

  // Es wurde eine chatId geschickt, die wir nicht kennen
  if (!history) {
    res.status(404).json({ error: 'Chat not found' });
    return;
  }

  // Neuen Prompt an bisherigen Chatverlauf anhängen.
  // Das Modell sieht nur, was in messages steht. Darum schicken wir jedes Mal den ganzen Verlauf mit.
  // Häufig ist es wichtig, dass die genaue Reihenfolge und auch Extra-Blöcke, wie thinking genau erhalten bleiben; z.B. für das Caching.
  const messages = [...history, { role: 'user', content: prompt }];

  // Request gegen Anthropic API
  const message = await client.beta.messages.create({
    model: 'claude-haiku-5-5',
    // system: 'Du bist ein Sandmännchen und sollst uns zum Einschlafen bringen',
    messages,
    // Obergrenze für die Länge der Antwort (in Tokens)
    max_tokens: 16000,
  });

  // Chatverlauf aktualisieren: die Antwort als 'assistant'-Message speichern, damit der nächste Request sie kennt
  const id = chatId ?? randomUUID();
  const newMessagesArr = messages.concat({ role: 'assistant', content: message.content });
  chats.set(id, newMessagesArr); // Platzhalter für DB write

  // Response: die chatId geht an den Client zurück, damit er den Chat beim nächsten Request fortsetzen kann
  res.json({ answer: message.content, chatId: id });
};

// ---------- Bildbeschreibung mit strukturiertem Output ----------

// Bildformate, die Claude versteht. 'as const' macht daraus feste Werte statt nur string[],
// damit TypeScript weiß, dass media_type unten genau einer davon ist.
const ALLOWED_IMAGE_TYPES = ['image/png', 'image/jpeg', 'image/webp', 'image/gif'] as const;

// So soll die Antwort von Claude aussehen. Mit .describe() erklären wir dem Modell, was in jedes Feld gehört.
const ImageSchema = z.object({
  altText: z.string().describe('One short German sentence for the alt attribute, at most 125 characters.'),
  description: z.string().describe('Two to four German sentences describing what is visible.'),
});

const imageDescriptionHandler: RequestHandler = async (req, res) => {
  // console.log(req.is('image/webp'));

  // req.is() prüft den Content-Type-Header des Requests. Wir merken uns den passenden Typ,
  // weil die API wissen muss, in welchem Format die Bilddaten sind.
  const media_type = ALLOWED_IMAGE_TYPES.find((type) => req.is(type));
  if (!media_type || req.body.lenght === 0) {
    res.status(400).json({ error: 'Image required' });
    return;
  }

  // req.body ist hier ein Buffer (rohe Bytes, siehe express.raw() in der Route).
  // Die API erwartet das Bild als Base64-Text, also wandeln wir es um.
  const imageData: string = req.body.toString('base64');

  // parse() statt create(): das SDK prüft die Antwort gegen unser Zod-Schema und gibt sie als fertiges Objekt zurück
  const message = await client.beta.messages.parse({
    model: 'claude-sonnet-5-5',
    max_tokens: 16000,
    system: 'Du bist ein Experte für Accessibility und erstellst alt-Texte für  Bilder.',
    messages: [
      {
        role: 'user',
        // content ist hier kein String, sondern ein Array von Blöcken: so können wir Bild und Text in einer Message schicken
        content: [
          { type: 'image', source: { type: 'base64', data: imageData, media_type } },
          { type: 'text', text: 'Describe this picture' },
        ],
      },
    ],
    // Strukturierter Output: Claude muss JSON liefern, das genau zu ImageSchema passt
    output_config: { format: betaZodOutputFormat(ImageSchema) },
  });

  // parsed_output ist bereits ein Objekt { altText, description }
  res.json({ message: message.parsed_output });
};

export { chatHandler, imageDescriptionHandler, ALLOWED_IMAGE_TYPES };
