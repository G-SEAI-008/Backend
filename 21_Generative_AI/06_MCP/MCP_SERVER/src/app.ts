import { createMcpExpressApp } from '@modelcontextprotocol/express';
import { toNodeHandler } from '@modelcontextprotocol/node';
import { createMcpHandler } from '@modelcontextprotocol/server';
import { createServer } from './mcpServer.ts';

const port = Number(process.env.PORT ?? 3002);

const app = createMcpExpressApp({
	allowedHosts: ['localhost', '127.0.0.1', 'host.docker.internal'],
});

const mcpHandler = toNodeHandler(createMcpHandler(createServer));

app.all('/mcp', (req, res) => {
	console.log(`MCP ${req.body?.method ?? req.method}`);
	void mcpHandler(req, res, req.body);
});

app.listen(port, () => {
	console.log(`MCP server on http://localhost:${port}/mcp`);
});
