// Local, read-only migration: writes only sign-in records, never old banking state.
const fs = require('node:fs');
const { DatabaseSync } = require('node:sqlite');
const [source, destination] = process.argv.slice(2);
if (!source || !destination) throw new Error('Usage: node export-users.cjs <SQLite path> <local JSON path>');
const db = new DatabaseSync(source, { readOnly: true });
try {
  const users = db.prepare('SELECT id, display_name, email, password_hash FROM users').all();
  fs.writeFileSync(destination, JSON.stringify(users), { flag: 'wx' });
  console.log(`Prepared ${users.length} sign-ins for local import.`);
} finally { db.close(); }
