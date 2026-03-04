using System;
using System.Net;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例實體
/// </summary>
public class Sample : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; private set; } = string.Empty;

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
    public IPAddress? IPAddress { get; set; }

    private Sample()
    {
        /* for deserialization / ORM purpose */
    }

    public Sample(
        Guid id,
        string name,
        DateTime dateTimeWithOutTimeZone,
        DateTimeOffset dateTimeWithTimeZone,
        SampleType sampleType,
        IPAddress? ipAddress = null)
        : base(id)
    {
        SetName(name);
        DateTimeWithOutTimeZone = dateTimeWithOutTimeZone;
        DateTimeWithTimeZone = dateTimeWithTimeZone;
        SampleType = sampleType;
        IPAddress = ipAddress;
    }

    internal Sample SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), SampleConsts.NameMaxLength);
        return this;
    }
}
