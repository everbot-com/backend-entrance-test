import type { MessageHandler, MessageHandlerResponse } from '../types'

interface EmailPayload {
    to: string
    subject: string
    body: string
}

export class EmailHandler implements MessageHandler {
    type = 'email'

    async handle(payload: EmailPayload): Promise<MessageHandlerResponse> {
        return {
            success: true,
            message: 'Email sent successfully',
            data: {
                messageId: `msg-${Date.now()}`,
                status: 'sent',
            }
        }
    }
}