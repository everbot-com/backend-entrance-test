using System.Threading.Tasks;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息處理器介面
/// </summary>
public interface IMessageHandler
{
    /// <summary>
    /// 對應的訊息類型
    /// </summary>
    MessageType MessageType { get; }

    /// <summary>
    /// 發送訊息
    /// </summary>
    Task<MessageResponseDto> SendAsync(MessageRequestDto input);
}
