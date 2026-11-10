import type { RequestHandler } from 'express';
import Anthropic from '@anthropic-ai/sdk';
import { z } from 'zod';

const client = new Anthropic({ apiKey: process.env.ANTHROPIC_API_KEY });

const PromptBody = z.object({
  prompt: z.string().min(1),
});

export const claudeChat: RequestHandler = async (req, res) => {
  const { prompt } = PromptBody.parse(req.body);

  const message = await client.messages.create({
    model: 'claude-sonnet-5-5',
    max_tokens: 256,
    system: 'You are a helpful assistant. Answer briefly',
    messages: [{ role: 'user', content: prompt }],
  });

  //   console.log(message);

  //   const text = message.content
  //     .filter((block) => block.type === 'text')
  //     .map((block) => block.text)
  //     .join('');

  res.json({ result: message });
};
