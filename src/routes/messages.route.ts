import type { MessageHandlerResponse } from '../types'
import type { MessageProcessor } from '../processor/message-processor'

function response(data: MessageHandlerResponse, status: number): Response {
    return new Response(JSON.stringify(data), {
        status,
        headers: { "Content-Type": "application/json" }
    })
}

export async function handleRequest(request: Request, processor: MessageProcessor): Promise<Response> {
    const url = new URL(request.url)

    if (request.method !== 'POST' || url.pathname !== '/messages') {
        return response({ success: false, message: 'Not found' }, 404)
    }

    let body: { type?: string; payload?: unknown }
    try {
        body = await request.json() as { type?: string; payload?: unknown }
    } catch {
        return response({ success: false, message: 'Invalid JSON body' }, 400)
    }

    if (!body.type || !body.payload) {
        return response({ success: false, message: 'Missing required fields: type, payload' }, 400)
    }

    try {
        const result = await processor.dispatch({ type: body.type, payload: body.payload })

        if (!result.success) {
            return response(result, 404)
        }

        return response(result, 200)
    } catch {
        return response({ success: false, message: 'Internal server error' }, 500)
    }
}
