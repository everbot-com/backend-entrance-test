import { handleEmail } from "../handlers/email.handler";
import { handleSms } from "../handlers/sms.handler";

export type MessageType = "email" | "sms";

export interface MessageRequest {
  type: MessageType;
  payload: any;
}

export async function processMessage({ type, payload }: MessageRequest) {
  switch (type) {
    case "email":
      return handleEmail(payload);

    case "sms":
      return handleSms(payload);

    default:
      const _exhaustive: never = type;
      throw new Error("Unknown message type");
  }
}
