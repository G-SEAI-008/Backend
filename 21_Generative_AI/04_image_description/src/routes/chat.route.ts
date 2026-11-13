import express, { Router } from 'express';
import { ALLOWED_IMAGE_TYPES, chatHandler, imageDescriptionHandler } from '../controller/chat.controller.ts';

const chatRouter = Router();

chatRouter.post('/', chatHandler);
chatRouter.post(
  '/image-description',
  // Bilder kommen nicht als JSON, sondern als rohe Bytes. express.raw() legt sie als Buffer in req.body ab,
  // aber nur, wenn der Content-Type passt. limit schützt davor, dass jemand riesige Dateien schickt.
  express.raw({ type: [...ALLOWED_IMAGE_TYPES], limit: '2mb' }),
  imageDescriptionHandler,
);

export default chatRouter;
