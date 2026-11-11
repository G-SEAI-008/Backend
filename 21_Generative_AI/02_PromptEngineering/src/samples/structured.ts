import Anthropic from '@anthropic-ai/sdk';
import { zodOutputFormat } from '@anthropic-ai/sdk/helpers/zod';
import { z } from 'zod';

const client = new Anthropic();

const Product = z.object({
  product_name: z.string(),
  category: z.string(),
  price: z.number(),
});

const message = await client.messages.parse({
  model: 'claude-haiku-5-5',
  max_tokens: 1024,
  system: 'Extract the fields from the product description.',
  messages: [
    {
      role: 'user',
      content: 'Product: UltraHD Monitor, Category: Electronics, Price: $299',
    },
  ],
  output_config: { format: zodOutputFormat(Product) },
});

console.log(message.parsed_output);
