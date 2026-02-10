export interface SmsPayload {
  to: string;
  message: string;
}

export async function handleSms(payload: SmsPayload) {
  if (!payload.to || !payload.message) {
    throw new Error("Invalid sms payload");
  }

  // mock 發送 sms
  return {
    messageId: "msg-sms-123",
    status: "sent",
  };
}
