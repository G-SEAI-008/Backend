import Anthropic from '@anthropic-ai/sdk';
import { tools, runTool } from './event-tools.ts';

const client = new Anthropic();

const model = process.env.LLM_MODEL ?? 'claude-haiku-5-5';
const MAX_STEPS = 5;

async function ask(question: string): Promise<string> {
	const messages: Anthropic.MessageParam[] = [
		{ role: 'user', content: question },
	];

	for (let step = 1; step <= MAX_STEPS; step++) {
		const message = await client.messages.create({
			model,
			max_tokens: 4096,
			system: `You answer questions about events using your tools. Today is ${new Date().toDateString()}.`,
			tools,
			messages,
		});

		messages.push({ role: 'assistant', content: message.content });

		if (message.stop_reason === 'end_turn') {
			return message.content
				.filter((block) => block.type === 'text')
				.map((block) => block.text)
				.join('');
		}

		if (message.stop_reason !== 'tool_use') {
			throw new Error(`Unexpected stop reason: ${message.stop_reason}`);
		}

		const toolUses = message.content.filter(
			(block) => block.type === 'tool_use',
		);

		const results = await Promise.all(
			toolUses.map(
				async (toolUse): Promise<Anthropic.ToolResultBlockParam> => {
					console.log(`Step ${step}: ${toolUse.name}`, toolUse.input);
					try {
						const content = await runTool(
							toolUse.name,
							toolUse.input,
						);
						return {
							type: 'tool_result',
							tool_use_id: toolUse.id,
							content,
						};
					} catch (err) {
						const content =
							err instanceof Error ? err.message : String(err);
						return {
							type: 'tool_result',
							tool_use_id: toolUse.id,
							content,
							is_error: true,
						};
					}
				},
			),
		);
		messages.push({ role: 'user', content: results });
	}
	throw new Error(`No answer after ${MAX_STEPS} steps`);
}

const question =
	process.argv[2] ??
	'What are the next three events, and what is the the first one about';

console.log(await ask(question));
