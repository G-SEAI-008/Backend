import { Router } from 'express';
import { echo, getRequestTest, putRequestTest } from '../controllers/ai.ts';
import { chatCompletion } from '../controllers/legacy.ts';

const aiRouter = Router();

aiRouter.post('/echo', echo);
aiRouter.get('/echo', getRequestTest);
aiRouter.put('/echo', putRequestTest);
aiRouter.post('/legacy', chatCompletion);

export default aiRouter;
