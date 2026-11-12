import Anthropic from '@anthropic-ai/sdk';
import type { RequestHandler } from 'express';
import { z } from 'zod';

const client = new Anthropic();

const PromptBody = z.object({
  prompt: z.string().min(1),
});

export const streamCompletion: RequestHandler = async (req, res) => {
  const { prompt } = PromptBody.parse(req.body);

  res.setHeader('Content-type', 'text/event-stream');

  const stream = client.messages.stream({
    model: 'claude-haiku-5-5',
    max_tokens: 1024,
    messages: [{ role: 'user', content: prompt }],
  });

  stream.on('text', (text) => {
    res.write(`data: ${JSON.stringify({ text })}\n\n`);
  });

  const message = await stream.finalMessage();
  console.log('\n', message.stop_reason, message.usage.output_tokens);
  res.end();
};
