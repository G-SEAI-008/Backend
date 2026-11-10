import { Router } from 'express';
import { claudeChat } from '../controllers/claude.ts';

const claudeRouter = Router();

claudeRouter.post('/chat', claudeChat);

export default claudeRouter;
