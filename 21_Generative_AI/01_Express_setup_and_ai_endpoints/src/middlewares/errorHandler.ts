import type { ErrorRequestHandler } from 'express';
import { ZodError } from 'zod';

export const errorHandler: ErrorRequestHandler = (err, _req, res, _next) => {
  if (err instanceof ZodError) {
    res.status(400).json({ error: err.issues });
    return;
  }

  const status = err.expose ? err.status : 500;
  if (status === 500) console.error(err);
  res
    .status(status)
    .json({ error: status === 500 ? 'Something went wrong' : err.message });
};
