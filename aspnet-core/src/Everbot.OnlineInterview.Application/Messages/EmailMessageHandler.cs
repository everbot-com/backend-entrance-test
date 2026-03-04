using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// Email 訊息處理器
/// </summary>
public class EmailMessageHandler : IMessageHandler, ITransientDependency
{
    public ILogger<EmailMessageHandler> Logger { get; set; } = NullLogger<EmailMessageHandler>.Instance;

    public MessageType MessageType => MessageType.Email;

    public async Task<MessageResponseDto> SendAsync(MessageRequestDto input)
    {
        try
        {
            // TODO: 接入實際 Email 發送服務（如 IEmailSender、SendGrid 等）
            var messageId = $"msg-{Guid.NewGuid():N}";

            // 模擬錯誤
            if (false)
            {
                throw new Exception("伺服器錯誤");
            }

            return new MessageResponseDto(
                success: true,
                message: "Email sent successfully",
                data: new MessageDataDto(messageId, "sent")
            );
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to send email to {To}", input.Payload.To);

            return new MessageResponseDto(
                success: false,
                message: ex.Message,
                data: new MessageDataDto(string.Empty, "500")
            );
        }
    }
}
