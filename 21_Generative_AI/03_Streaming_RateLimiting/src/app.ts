import express from 'express';
import { errorHandler } from './middlewares/errorHandler.ts';
import claudeRouter from './routes/claudeRoutes.ts';
import rateLimit from 'express-rate-limit';

const app = express();
const port = 3000;

app.use(express.json());

app.use('/claude', claudeRouter);

app.use(errorHandler);

app.listen(port, () =>
  console.log(`listening on port: http://localhost:${port}`),
);
