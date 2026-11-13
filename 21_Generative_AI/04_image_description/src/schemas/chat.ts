import z from 'zod';

// Beschreibt, wie der Request-Body aussehen muss. parse() wirft einen ZodError, wenn etwas nicht passt.
const ChatBody = z.object({
  prompt: z.string({ error: 'Prompt must be a string' }).trim().min(1).max(2000),
  // Ohne chatId startet ein neuer Chat, mit chatId wird ein bestehender fortgesetzt
  chatId: z.uuid().optional(),
});

export { ChatBody };
