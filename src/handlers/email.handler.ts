export interface EmailPayload {
  to: string;
  subject: string;
  body: string;
}

export async function handleEmail(payload: EmailPayload) {
  if (!payload.to || !payload.subject || !payload.body) {
    throw new Error("Invalid email payload");
  }

  // mock 發送 email
  return {
    messageId: "msg-email-123",
    status: "sent",
  };
}
