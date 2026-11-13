import Anthropic from '@anthropic-ai/sdk';
import type { ErrorRequestHandler } from 'express';
import { ZodError } from 'zod';

// Express erkennt einen Error-Handler an den vier Parametern (err, req, res, next)
const errorHandler: ErrorRequestHandler = (err, _req, res, _next) => {
  // Ungültige Eingaben vom Client -> 400 Bad Request mit den Details von Zod
  if (err instanceof ZodError) {
    res.status(400).json({ error: err.issues });
    return;
  }

  // if(err instanceof Anthropic.RateLimitError)

  // Fehler von der Anthropic API -> 502 Bad Gateway: nicht unser Server ist kaputt, sondern der Dienst dahinter.
  // Die Details loggen wir nur intern, der Client bekommt eine allgemeine Meldung.
  if (err instanceof Anthropic.AnthropicError) {
    console.error(err);
    res.status(502).json({
      error: 'The AI service could not complete this request',
    });
  }

  // Alle anderen Fehler. err.expose ist bei Fehlern von Express-Middlewares gesetzt (z. B. 413 bei zu großem Body).
  const status = err.expose ? err.status : 500;
  if (status === 500) console.error(err);
  res.status(status).json({ error: status === 500 ? 'Something went wrong' : err.message });
};

export { errorHandler };
