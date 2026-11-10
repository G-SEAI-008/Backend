import type { RequestHandler } from 'express';

type OpenAIChatResponse = {
  choices: {
    message: {
      content: string;
    };
  }[];
};

export const chatCompletion: RequestHandler = async (req, res) => {
  const { prompt } = req.body as { prompt: string };

  const response = await fetch('https://api.openai.com/v1/chat/completions', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${process.env.OPENAI_API_KEY}`,
    },
    body: JSON.stringify({
      model: 'gpt-4o-mini',
      messages: [
        {
          role: 'system',
          content: 'You are a helpful asssitant',
        },
        { role: 'user', content: prompt },
      ],
    }),
  });

  const data = (await response.json()) as OpenAIChatResponse;
  const message = data.choices[0]?.message.content;

  res.json({ result: message });
};
