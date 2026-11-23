const baseUrl = process.env.EVENTS_API_URL ?? 'http://localhost:3001';
const token = process.env.EVENTS_API_TOKEN ?? '';

export type EventItem = {
	id: number;
	title: string;
	description?: string;
	date: string;
	location: string;
	organizerId: number;
};

export async function eventsApi<T>(
	path: string,
	init: RequestInit = {},
): Promise<T> {
	const response = await fetch(`${baseUrl}/${path}`, {
		...init,
		headers: {
			'Content-Type': 'application/json',
			Authorization: `Bearer ${token}`,
			...init.headers,
		},
	});

	if (!response.ok) {
		throw new Error(
			`Events API return ${response.status}: ${await response.text()}`,
		);
	}
	return (await response.json()) as T;
}
