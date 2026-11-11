import Anthropic from '@anthropic-ai/sdk';

const client = new Anthropic();

const ask = async (prompt: string) => {
  const message = await client.messages.create({
    model: 'claude-haiku-5-5',
    max_tokens: 1024,
    messages: [{ role: 'user', content: prompt }],
  });
  for (const block of message.content) {
    if (block.type === 'text') console.log(block.text, '\n');
  }
};

const text =
  'Alice gave a short update on the project. No action items were required.';

console.log('=== ZERO SHOT ===');
await ask(`Extract the speaker, topic and action items from this text. Return JSON.

<text>${text}</text>`);

console.log('=== ONE SHOT ===');
await ask(`Extract the speaker, topic and action items from the text.

Example:
Text: Bob reviewed last quarter's expenses and asked Alice to update the budget by Monday.
Output: {"speaker": "Bob", "topic": "last quarter's expenses", "action_items": "Alice to update the budget by Monday"}

<text>${text}</text>`);

console.log('=== FEW SHOT ===');
await ask(`Extract the speaker, topic and action items from the text.

Examples:
Text: Bob reviewed last quarter's expenses and asked Alice to update the budget by Monday.
Output: {"speaker": "Bob", "topic": "last quarter's expenses", "action_items": "Alice to update the budget by Monday"}

Text: Charlie outlined the marketing strategy and asked Dana to draft a social media plan.
Output: {"speaker": "Charlie", "topic": "marketing strategy", "action_items": "Dana to draft a social media plan"}

Text: Erin gave a short update on hiring. Nobody was asked to do anything.
Output: {"speaker": "Erin", "topic": "hiring", "action_items": null}

<text>${text}</text>`);
