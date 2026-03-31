import { handleRequest } from './src/routes/messages.route'
import { MessageProcessor } from './src/processor/message-processor'
import { EmailHandler } from './src/handlers/email.handler'
import { SmsHandler } from './src/handlers/sms.handler'

const processor = new MessageProcessor()
processor.registerHandler('email', new EmailHandler())
processor.registerHandler('sms', new SmsHandler())

Bun.serve({
    port: 3000,
    fetch(request) {
        return handleRequest(request, processor)
    }
})