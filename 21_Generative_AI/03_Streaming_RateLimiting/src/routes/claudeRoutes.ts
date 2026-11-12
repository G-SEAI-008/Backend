import { Router } from 'express';
import { claudeChat } from '../controllers/claude.ts';
import { streamCompletion } from '../controllers/stream.ts';
import { checkLimits } from '../controllers/limits.ts';
import rateLimit from 'express-rate-limit';

const claudeRouter = Router();

claudeRouter.use(
  rateLimit({
    windowMs: 60_000,
    limit: 2,
    message: {
      error: 'too many requests',
    },
  }),
);

claudeRouter.post('/chat', claudeChat);
claudeRouter.post('/stream', streamCompletion);
claudeRouter.get('/limits', checkLimits);

export default claudeRouter;
