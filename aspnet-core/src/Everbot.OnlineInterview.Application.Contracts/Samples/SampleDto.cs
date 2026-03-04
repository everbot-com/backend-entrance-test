using System;
using Volo.Abp.Application.Dtos;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例實體 DTO
/// </summary>
public class SampleDto : ExtensibleFullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 時間(不含時區)
    /// </summary>
    public DateTime DateTimeWithOutTimeZone { get; set; }

    /// <summary>
    /// 時間(含時區)
    /// </summary>
    public DateTimeOffset DateTimeWithTimeZone { get; set; }

    /// <summary>
    /// 類型
    /// </summary>
    public SampleType SampleType { get; set; }

    /// <summary>
    /// IP位址
    /// </summary>
    public string IPAddress { get; set; } = string.Empty;

    public SampleDto() { }

    public SampleDto(
        Guid id,
        string name,
        DateTime dateTimeWithOutTimeZone,
        DateTimeOffset dateTimeWithTimeZone,
        SampleType sampleType,
        string ipAddress = ""
    )
    {
        Id = id;
        Name = name;
        DateTimeWithOutTimeZone = dateTimeWithOutTimeZone;
        DateTimeWithTimeZone = dateTimeWithTimeZone;
        SampleType = sampleType;
        IPAddress = ipAddress;
    }
}
