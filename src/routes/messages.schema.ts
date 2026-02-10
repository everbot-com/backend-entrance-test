import { z } from "zod";

/**
 * Email payload
 */
const EmailPayloadSchema = z.object({
  to: z.string().email(),
  subject: z.string().min(1),
  body: z.string().min(1),
});

/**
 * SMS payload
 */
const SmsPayloadSchema = z.object({
  to: z.string().min(1),
  message: z.string().min(1),
});

/**
 * Discriminated Union
 * type 決定 payload 結構
 */
export const MessageSchema = z.discriminatedUnion("type", [
  z.object({
    type: z.literal("email"),
    payload: EmailPayloadSchema,
  }),
  z.object({
    type: z.literal("sms"),
    payload: SmsPayloadSchema,
  }),
]);

/**
 * 導出 TS 型別（由 Zod 反推）
 */
export type MessageInput = z.infer<typeof MessageSchema>;
