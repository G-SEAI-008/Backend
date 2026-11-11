import { Router } from 'express';
import { echo, getRequestTest, putRequestTest } from '../controllers/ai.ts';

const aiRouter = Router();

aiRouter.post('/echo', echo);
aiRouter.get('/echo', getRequestTest);
aiRouter.put('/echo', putRequestTest);

export default aiRouter;
