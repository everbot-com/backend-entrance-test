using System.ComponentModel;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例類型
/// </summary>
public enum SampleType : byte
{
    /// <summary>
    /// 類型一
    /// </summary>
    [Description("類型一")]
    Type1 = 1,

    /// <summary>
    /// 類型二
    /// </summary>
    [Description("類型二")]
    Type2 = 2,
}
