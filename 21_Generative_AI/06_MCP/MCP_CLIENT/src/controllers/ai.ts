import type { RequestHandler } from 'express';
import { z } from 'zod';

const PromptBody = z.object({
  prompt: z.string().min(1),
});

export const echo: RequestHandler = async (req, res) => {
  const { prompt } = PromptBody.parse(req.body);

  res.json({ reply: prompt.toUpperCase() });
};

export const getRequestTest: RequestHandler = async (req, res) => {
  // console.log(req);

  res.json({
    message: `GET Reuqest to: ${req.url}`,
  });
};

export const putRequestTest: RequestHandler = async (req, res) => {
  res.json({
    message: `${req.method} Request to ${req.url}`,
  });
};
