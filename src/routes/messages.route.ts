import { MessageSchema } from "./messages.schema";
import { processMessage } from "../processor/message-processor";

export async function messagesRoute(req: Request): Promise<Response> {
  try {
    if (req.method !== "POST") {
      return new Response("Method Not Allowed", { status: 405 });
    }

    const body = await req.json();

    const parsed = MessageSchema.safeParse(body);

    if (!parsed.success) {
      return Response.json(
        {
          success: false,
          message: "Invalid request body",
          errors: parsed.error.flatten(),
        },
        { status: 400 }
      );
    }

    // 🎯 TS 在這裡已經知道型別了！
    const { type, payload } = parsed.data;

    const result = await processMessage({ type, payload });

    return Response.json(
      {
        success: true,
        message: `${type} sent successfully`,
        data: result,
      },
      { status: 200 }
    );
  } catch (err: any) {
    return Response.json(
      { success: false, message: err.message ?? "Server error" },
      { status: 500 }
    );
  }
}
