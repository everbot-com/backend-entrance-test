namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例實體建立 DTO
/// </summary>
public class SampleCreateInputDto
{
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 類型
    /// </summary>
    public SampleType SampleType { get; set; }
}
