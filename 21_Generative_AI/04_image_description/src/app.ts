import express from 'express';
import chatRouter from './routes/chat.route.ts';
import { errorHandler } from './middlewares/errorHandler.ts';

const app = express();

// Middleware: liest JSON-Bodies und legt sie als Objekt in req.body ab
app.use(express.json());

app.get('/', (req, res) => {
  res.json({ msg: 'Hello, World' });
});

// Alle Routen unter /chat übernimmt der chatRouter (z. B. POST /chat, POST /chat/image-description)
app.use('/chat', chatRouter);

// Der Error-Handler kommt als letztes: Fehler aus allen Routen landen hier
app.use(errorHandler);

app.listen(3000, () => {
  console.log(`Server läuft auf port 3000`);
});
