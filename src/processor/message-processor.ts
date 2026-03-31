import type {MessageRequest, MessageHandler, MessageHandlerResponse} from "../types.ts";

export class MessageProcessor {
    private handlers = new Map<string, MessageHandler>()

    registerHandler(type: string, handler: MessageHandler) {
        this.handlers.set(type, handler)
    }

    async dispatch(request: MessageRequest): Promise<MessageHandlerResponse> {
        const handler = this.handlers.get(request.type)
        if (!handler) {
            return {
                success: false,
                message: `No handler found for type: ${request.type}`
            }
        }
        return handler.handle(request.payload)
    }
}