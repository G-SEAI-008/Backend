import Anthropic from '@anthropic-ai/sdk';
import type { ErrorRequestHandler } from 'express';
import { ZodError } from 'zod';

export const errorHandler: ErrorRequestHandler = (err, _req, res, _next) => {
  if (err instanceof ZodError) {
    res.status(400).json({ error: err.issues });
    return;
  }

  // if(err instanceof Anthropic.RateLimitError)

  if (err instanceof Anthropic.AnthropicError) {
    console.error(err);
    res.status(502).json({
      error: 'The AI service could not complete this request',
    });
  }

  const status = err.expose ? err.status : 500;
  if (status === 500) console.error(err);
  res
    .status(status)
    .json({ error: status === 500 ? 'Something went wrong' : err.message });
};
