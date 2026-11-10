# WBS Node.js TypeScript Backend Scaffold

A modern, production-ready backend scaffold for TypeScript, Node and native ES modules.

In development, Node runs the `.ts` files directly. For production, TypeScript compiles the project to JavaScript in `dist/`.

## 🚀 Quick Start

```bash
# Clone the template repository
git clone https://github.com/WebDev-WBSCodingSchool/wbs-node-ts-template.git your-project-name

# Navigate to your project
cd your-project-name

# Remove the template git history and start a new repository
rm -rf .git
git init

# Install dependencies
npm install

# Start development
npm run dev
```

## 📁 Project Structure

```bash
.
├── package-lock.json   # Dependency lock file
├── package.json        # Scripts, dependencies, and Node package imports
├── README.md           # Project documentation
├── src
│   └── app.ts          # Application entry point
└── tsconfig.json       # TypeScript configuration
```

The `dist/` directory is created when you run `npm run build`.

## 🛠 Available Scripts

| Command            | Description                                             |
| ------------------ | ------------------------------------------------------- |
| `npm run dev`      | Run `src/app.ts` directly with Node and restart on save |
| `npm run build`    | Compile TypeScript from `src/` to JavaScript in `dist/` |
| `npm run start`    | Build first, then run `dist/app.js`                     |
| `npm run prebuild` | Remove the old `dist/` directory before building        |
| `npm run prestart` | Build automatically before `npm run start`              |

## 🔧 Features

### Modern TypeScript Configuration

- **ES2025** target for modern Node.js projects
- **Strict mode** enabled by default in TypeScript 7
- **Native Node.js ESM** support with `NodeNext`
- **Node package imports** with `#` aliases via `package.json#imports`
- **TypeScript import extensions** support for direct Node development
- **Build output** from `src/` to `dist/`
- **Node-compatible TypeScript syntax** for running `.ts` files directly in development

## Development vs Production

During development, Node runs the TypeScript files in `src/` directly.

For production, TypeScript compiles `src/` to JavaScript in `dist/`, and Node runs the compiled output.

Node does not read `tsconfig.json` at runtime. Use it for type-checking and compilation settings; runtime import aliases belong in `package.json`.

## Package Imports

Use Node's `package.json#imports` for internal aliases that start with `#`.

Example:

```jsonc
{
  "imports": {
    "#utils": {
      "development": "./src/utils/index.ts",
      "default": "./dist/utils/index.js",
    },
  },
}
```

Then import from code:

```ts
import { helper } from '#utils';
```

The `"development"` condition points Node to the `.ts` source files during development. The `"default"` condition points Node to the compiled `.js` files in `dist/`.

Prefer `package.json#imports` for Node backend aliases. Use `tsconfig.paths` only when your runtime or bundler also understands the same alias.

## JSON Imports

With `module: "NodeNext"`, TypeScript follows Node's ES module rules. JSON imports need an import attribute:

```ts
import data from './data.json' with { type: 'json' };
```

## 📦 Dependencies

This template starts with no runtime dependencies (pure Node.js setup ready for your additions).
