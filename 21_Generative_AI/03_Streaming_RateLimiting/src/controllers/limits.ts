import Anthropic from '@anthropic-ai/sdk';
import type { RequestHandler } from 'express';

const client = new Anthropic();

export const checkLimits: RequestHandler = async (req, res) => {
  const { data: message, response } = await client.messages
    .create({
      model: 'claude-haiku-5-5',
      max_tokens: 64,
      messages: [{ role: 'user', content: 'Hello' }],
    })
    .withResponse();

  const text = message.content
    .filter((block) => block.type === 'text')
    .map((block) => block.text)
    .join('');

  res.json({
    reply: text,
    usage: message.usage,
    limits: {
      requestRemaining: response.headers.get(
        'anthropic-ratelimit-requests-remaining',
      ),
      inputTokenRemaining: response.headers.get(
        'anthropic-ratelimit-input-tokens-remaining',
      ),
      outputTokenRemaining: response.headers.get(
        'anthropic-ratelimit-output-tokens-remaining',
      ),
    },
  });
};
