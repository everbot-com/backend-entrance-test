using System.ComponentModel.DataAnnotations;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息內容
/// </summary>
public class MessagePayloadDto
{
    /// <summary>
    /// 收件人
    /// </summary>
    [Required]
    public string To { get; set; } = string.Empty;

    /// <summary>
    /// 主旨
    /// </summary>
    [Required]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// 內容
    /// </summary>
    [Required]
    public string Body { get; set; } = string.Empty;
}
