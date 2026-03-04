using System;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例管理
/// </summary>
public class SampleManager : DomainService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleManager(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    /// <summary>
    /// 建立範例
    /// </summary>
    public async Task<Sample> CreateAsync(
        string name,
        DateTime dateTimeWithOutTimeZone,
        DateTimeOffset dateTimeWithTimeZone,
        SampleType sampleType,
        IPAddress? ipAddress = null)
    {
        return new Sample(
            GuidGenerator.Create(),
            name,
            dateTimeWithOutTimeZone,
            dateTimeWithTimeZone,
            sampleType,
            ipAddress);
    }

    /// <summary>
    /// 更新範例
    /// </summary>
    public async Task<Sample> UpdateAsync(
        Sample sample,
        string name,
        DateTime dateTimeWithOutTimeZone,
        DateTimeOffset dateTimeWithTimeZone,
        SampleType sampleType,
        IPAddress? ipAddress = null)
    {
        sample.SetName(name);
        sample.DateTimeWithOutTimeZone = dateTimeWithOutTimeZone;
        sample.DateTimeWithTimeZone = dateTimeWithTimeZone;
        sample.SampleType = sampleType;
        sample.IPAddress = ipAddress;

        return await _sampleRepository.UpdateAsync(sample);
    }
}
