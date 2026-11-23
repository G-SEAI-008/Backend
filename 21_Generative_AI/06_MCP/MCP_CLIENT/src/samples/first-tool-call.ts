import Anthropic from '@anthropic-ai/sdk';
import { runTool, tools } from './event-tools.ts';

const client = new Anthropic();
const model = process.env.LLM_MODEL ?? 'claude-haiku-5-5';

const messages: Anthropic.MessageParam[] = [
	{ role: 'user', content: 'What are the next three events' },
];

const first = await client.messages.create({
	model,
	max_tokens: 4096,
	tools,
	messages,
});

// console.log(first.stop_reason);
// console.log(first.content, { depth: null });

messages.push({ role: 'assistant', content: first.content });

const toolResults: Anthropic.ToolResultBlockParam[] = [];

for (const block of first.content) {
	if (block.type === 'tool_use') {
		const content = await runTool(block.name, block.input);
		toolResults.push({
			type: 'tool_result',
			tool_use_id: block.id,
			content,
		});
	}
}

messages.push({ role: 'user', content: toolResults });

const second = await client.messages.create({
	model,
	max_tokens: 4096,
	tools,
	messages,
});

for (const block of second.content) {
	if (block.type === 'text') console.log(block.text);
}
