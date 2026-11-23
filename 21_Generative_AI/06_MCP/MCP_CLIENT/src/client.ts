import {
	Client,
	StreamableHTTPClientTransport,
} from '@modelcontextprotocol/client';
import { Anthropic } from '@anthropic-ai/sdk/client.js';

const mcp = new Client(
	{
		name: 'events-assitant',
		version: '1.0.0',
	},
	{ versionNegotiation: { mode: 'auto' } },
);

const serverUrl = 'http://localhost:3002/mcp';

await mcp.connect(new StreamableHTTPClientTransport(new URL(serverUrl)));

console.log(`Connected (${mcp.getProtocolEra}) protocol`);

const { tools } = await mcp.listTools();
console.log(`Tools: ${tools.map((t) => t.name).join(', ')}`);

const anthropicTools: Anthropic.Tool[] = tools.map((tool) => ({
	name: tool.name,
	description: tool.description ?? '',
	input_schema: tool.inputSchema as Anthropic.Tool.InputSchema,
}));

console.log(anthropicTools);
