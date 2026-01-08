# Backend Engineer Practical Test — Plugin-based Message Processing System

This repository contains a practical test for backend engineer candidates.  
The goal is to evaluate architecture design, TypeScript proficiency, API design, and extensibility thinking.

---

## 📌 Overview

Please implement a **plugin-based message processing system** using **TypeScript**.  
The system should accept different types of messages and dispatch them to the correct handler based on the message type.

**Note:**

- You can use any package manager (npm, yarn, bun, pnpm, etc.)
- If you're not familiar with TypeScript, you may use JavaScript instead (though TypeScript is preferred)

Example message:

```json
{
  "type": "email",
  "payload": {
    "to": "test@example.com",
    "subject": "Hello",
    "body": "World"
  }
}
```

Example response:

```json
{
  "success": true,
  "message": "Email sent successfully",
  "data": {
    "messageId": "msg-123",
    "status": "sent"
  }
}
```

The system must support at least:

- email
- sms

Future message types (e.g., LINE, Slack, Webhook) should be easy to add without modifying core logic.

---

## Requirements

### 1. API

Implement a POST endpoint:

**POST /messages**

Request Body:

```json
{
  "type": "email" | "sms",
  "payload": { ... }
}
```

- Accepts { type, payload }
- Dispatches to the correct handler
- Returns the handler's result
- Should return appropriate HTTP status codes (200 for success, 400 for bad request, 404 for unknown message type, 500 for server errors)

Framework is free to choose:

- Express
- Fastify
- NestJS
- Or native Node.js HTTP

---

### 2. Plugin Architecture

You must implement:

**MessageHandler interface (or abstract class)**

Defines:

- `type: string`
- `handle(payload: any): Promise<any> | any`

**Handlers**

Implement at least:

- EmailHandler
- SmsHandler

Each handler must implement the MessageHandler interface.

**MessageProcessor**

Responsible for:

- Registering handlers
- Mapping type → handler
- Dispatching messages
- Handling unknown types

---

### 3. Code Structure

Your code should be organized into modules, for example:

```text
src/
  handlers/
    email.handler.ts
    sms.handler.ts
  processor/
    message-processor.ts
  routes/
    messages.route.ts
  index.ts
```

Database is not required.
All data may be stored in memory.

---

## Bonus Points (Optional)

These are not required but will be considered a plus:

- Use of TypeScript features (interface, type, enum, generics)
- Dependency Injection or factory pattern
- Async handler support (simulate external API calls with delays)
- Input validation (Zod, class-validator, etc.)
- Comprehensive error handling (400/404/500 with meaningful error messages)
- Unit tests (Jest / Vitest) with good coverage
- Dynamic plugin loading (scan folder automatically)
- Logging (console.log is acceptable, but structured logging is a plus)
- Consistent error response format
- Type-safe payloads (using TypeScript types/interfaces instead of `any`)

---

## Submission

**Please fork this repository and submit a Pull Request (PR) when you've completed the implementation.**

Please provide:

- A GitHub repository link (make sure it's public or accessible)
- Clear instructions to run the project (including Node.js version requirement, if any)
- `package.json` with all necessary scripts (e.g., `npm start`, `npm run dev`)
- (Optional) Notes on design decisions and trade-offs
- (Optional) Brief explanation of your architecture choices

---

## Time Limit

You have **1 hour** to complete the implementation.

**Important Notes:**

- You may use AI tools to assist, but you should understand and be able to explain your code
- Focus on core functionality first, then add bonus features if time permits
- Code quality and architecture are more important than feature completeness
- Make sure the code compiles and runs without errors

---

Good luck, and have fun building!
