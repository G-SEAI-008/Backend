import Anthropic from '@anthropic-ai/sdk';

// Ein Client für die ganze App. Den API-Key liest das SDK automatisch aus ANTHROPIC_API_KEY in der .env.
const client = new Anthropic();

export { client };
