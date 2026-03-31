import type { MessageHandler, MessageHandlerResponse } from '../types'

interface SmsPayload {
    to: string
    message: string
}

export class SmsHandler implements MessageHandler {
    type = 'sms'

    async handle(payload: SmsPayload): Promise<MessageHandlerResponse> {
        return {
            success: true,
            message: 'SMS sent successfully',
            data: {
                messageId: `msg-${Date.now()}`,
                status: 'sent',
            }
        }
    }
}