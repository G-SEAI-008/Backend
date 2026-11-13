// Speichert alle Chatverläufe im Arbeitsspeicher: chatId -> Array von Messages.
// Die API selbst merkt sich nichts, deshalb müssen wir den Verlauf bei jedem Request mitschicken.
// Hier nur eine Platzhalter-Map.
// Für reale Chatverläufe eignen sich NoSQL-Datenbanken wie MongoDB, oder JSONB-Felder in Postgres sehr gut, da die Content-Blöcke sehr uneinheitlich sind.
const chats = new Map();

export { chats };
