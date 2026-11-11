import Anthropic from '@anthropic-ai/sdk';

const client = new Anthropic();

const prompt =
  'A shop offers refunds within 30 days. A customer requests a refund after 45 days. Explain whether the refund is allowed.';

for (const effort of ['low', 'high'] as const) {
  const message = await client.messages.create({
    model: 'claude-haiku-5-5',
    max_tokens: 1024,
    output_config: { effort },
    messages: [{ role: 'user', content: prompt }],
  });

  const text =
    message.content.find((block) => block.type === 'text')?.text ?? '';

  console.log(`\n=== EFFORT: ${effort.toUpperCase()} ===`);
  console.log('Answer:', text);
  console.log('Input tokens:', message.usage.input_tokens);
  console.log('Output tokens:', message.usage.output_tokens);
}
