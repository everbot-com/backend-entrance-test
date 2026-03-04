using System.ComponentModel.DataAnnotations;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息發送請求
/// </summary>
public class MessageRequestDto
{
    /// <summary>
    /// 訊息類型
    /// </summary>
    [Required]
    public MessageType Type { get; set; }

    /// <summary>
    /// 訊息內容
    /// </summary>
    [Required]
    public MessagePayloadDto Payload { get; set; } = null!;
}
