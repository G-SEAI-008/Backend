import { McpServer } from '@modelcontextprotocol/server';
import { z } from 'zod';
import { eventsApi, type EventItem } from './eventsApi.ts';

export function createServer(): McpServer {
	const server = new McpServer({ name: 'events-api', version: '1.0.0' });

	server.registerTool(
		'get_event',
		{
			description:
				'Get all details of one event by its id, including the description.',
			inputSchema: z.object({
				id: z.number().int().positive().describe('The id of the event'),
			}),
		},

		async ({ id }) => {
			try {
				const event = await eventsApi<EventItem | null>(
					`api/events/${id}`,
				);

				if (!event) {
					return {
						content: [
							{
								type: 'text',
								text: `No event with id ${id} exists`,
							},
						],
						isError: true,
					};
				}

				return {
					content: [{ type: 'text', text: JSON.stringify(event) }],
				};
			} catch (error) {
				return {
					content: [{ type: 'text', text: String(error) }],
					isError: true,
				};
			}
		},
	);
	return server;
}
