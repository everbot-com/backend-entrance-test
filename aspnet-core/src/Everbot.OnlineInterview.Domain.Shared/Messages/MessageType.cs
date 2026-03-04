using System.ComponentModel;

namespace Everbot.OnlineInterview.Messages;

/// <summary>
/// 訊息類型
/// </summary>
public enum MessageType : byte
{
    /// <summary>
    /// Email
    /// </summary>
    [Description("Email")]
    Email = 1,

    /// <summary>
    /// 簡訊
    /// </summary>
    [Description("簡訊")]
    Sms = 2,

    /// <summary>
    /// Line
    /// </summary>
    [Description("Line")]
    Line = 3,

    /// <summary>
    /// Slack
    /// </summary>
    [Description("Slack")]
    Slack = 4,

    /// <summary>
    /// Webhook
    /// </summary>
    [Description("Webhook")]
    Webhook = 5,
}
