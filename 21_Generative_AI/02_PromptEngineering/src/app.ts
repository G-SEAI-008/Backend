import express from 'express';
import aiRouter from './routes/aiRoutes.ts';
import { errorHandler } from './middlewares/errorHandler.ts';
import claudeRouter from './routes/claudeRoutes.ts';

const app = express();
const port = 3000;

// app.get('/hello', (req, res) => res.json({ message: 'Hello' }));

app.use(express.json());

app.use('/ai', aiRouter);
app.use('/claude', claudeRouter);

app.use(errorHandler);

app.listen(port, () =>
  console.log(`listening on port: http://localhost:${port}`),
);
