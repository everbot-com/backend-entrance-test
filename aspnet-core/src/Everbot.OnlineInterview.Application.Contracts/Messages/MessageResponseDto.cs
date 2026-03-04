namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息發送回應
/// </summary>
public class MessageResponseDto
{
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// 訊息描述
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// 發送結果資料
    /// </summary>
    public MessageDataDto Data { get; set; } = null!;

    public MessageResponseDto() { }

    public MessageResponseDto(bool success, string message, MessageDataDto data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}
