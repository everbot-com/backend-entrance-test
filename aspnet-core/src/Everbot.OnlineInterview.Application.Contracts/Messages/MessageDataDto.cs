namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息發送結果資料
/// </summary>
public class MessageDataDto
{
    /// <summary>
    /// 訊息 ID
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// 狀態
    /// </summary>
    public string Status { get; set; } = string.Empty;

    public MessageDataDto() { }

    public MessageDataDto(string messageId, string status)
    {
        MessageId = messageId;
        Status = status;
    }
}
