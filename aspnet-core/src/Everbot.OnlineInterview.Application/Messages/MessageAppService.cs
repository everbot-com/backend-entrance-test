using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息服務
/// </summary>
public class MessageAppService : OnlineInterviewAppService, IMessageAppService
{
    private readonly IEnumerable<IMessageHandler> _handlers;

    public MessageAppService(IEnumerable<IMessageHandler> handlers)
    {
        _handlers = handlers;
    }

    /// <summary>
    /// 發送訊息
    /// </summary>
    public async Task<MessageResponseDto> SendAsync(MessageRequestDto input)
    {
        try
        {
            var handler = _handlers.FirstOrDefault(h => h.MessageType == input.Type)
                ?? throw new Exception("未知訊息類型");

            return await handler.SendAsync(input);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to send email to {To}", input.Payload.To);

            return new MessageResponseDto(
                success: false,
                message: ex.Message,
                data: new MessageDataDto(string.Empty, "404")
            );
        }
    }
}
