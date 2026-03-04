namespace Everbot.OnlineInterview.Samples;

public class SampleUpdateInputDto
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
