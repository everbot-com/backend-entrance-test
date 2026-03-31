export interface MessageHandler {
    type: string
    handle(payload: any): Promise<any>
}

export interface MessageHandlerResponse {
    success: boolean
    message: string
    data?: Record<string, any>
}

export interface MessageRequest {
    type: string
    payload: unknown
}