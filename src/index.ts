import { messagesRoute } from "./routes/messages.route";

const server = Bun.serve({
  port: 3000,
  fetch(req) {
    const url = new URL(req.url);

    if (url.pathname === "/messages") {
      return messagesRoute(req);
    }

    return new Response("Not Found", { status: 404 });
  },
});

console.log(`🚀 Server running at http://localhost:${server.port}`);
