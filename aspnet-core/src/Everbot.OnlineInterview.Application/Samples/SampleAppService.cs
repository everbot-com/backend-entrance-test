using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Yuu.ClientInfo.Provider;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例服務
/// </summary>
public class SampleAppService : OnlineInterviewAppService, ISampleAppService
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IClientInfoProvider _clientInfoProvider;
    private readonly SampleManager _sampleManager;

    public SampleAppService(
        ISampleRepository sampleRepository,
        IClientInfoProvider clientInfoProvider,
        SampleManager sampleManager
    )
    {
        _sampleRepository = sampleRepository;
        _clientInfoProvider = clientInfoProvider;
        _sampleManager = sampleManager;
    }

    /// <summary>
    /// 取得列表
    /// </summary>
    public async Task<ExtensiblePagedResultDto<SampleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        if (string.IsNullOrWhiteSpace(input.Sorting))
        {
            input.Sorting = nameof(Sample.Name);
        }

        var filter = string.Empty;

        var samples = await _sampleRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            filter
        );

        var totalCount = string.IsNullOrWhiteSpace(filter)
            ? await _sampleRepository.CountAsync()
            : await _sampleRepository.CountAsync(s => s.Name.Contains(filter));

        return new ExtensiblePagedResultDto<SampleDto>(
            totalCount,
            ObjectMapper.Map<List<Sample>, List<SampleDto>>(samples)
        );
    }

    /// <summary>
    /// 取得項目
    /// </summary>
    public async Task<SampleDto> GetAsync(Guid id)
    {
        var sample = await _sampleRepository.GetAsync(id);

        return ObjectMapper.Map<Sample, SampleDto>(sample);
    }

    /// <summary>
    /// 新增項目
    /// </summary>
    public async Task<SampleDto> CreateAsync(SampleCreateInputDto input)
    {
        var sample = await _sampleManager.CreateAsync(
            input.Name,
            DateTime.Now,
            DateTimeOffset.Now,
            input.SampleType,
            IPAddress.Parse(_clientInfoProvider.ClientIpAddress!)
        );

        await _sampleRepository.InsertAsync(sample);

        return ObjectMapper.Map<Sample, SampleDto>(sample);
    }

    /// <summary>
    /// 編輯項目
    /// </summary>
    public async Task<SampleDto> UpdateAsync(Guid id, SampleUpdateInputDto input)
    {
        var sample = await _sampleRepository.GetAsync(id);

        var updated = await _sampleManager.UpdateAsync(
            sample,
            input.Name,
            sample.DateTimeWithOutTimeZone,
            sample.DateTimeWithTimeZone,
            input.SampleType,
            IPAddress.Parse(_clientInfoProvider.ClientIpAddress!)
        );

        return ObjectMapper.Map<Sample, SampleDto>(updated);
    }

    /// <summary>
    /// 刪除項目
    /// </summary>
    public async Task DeleteAsync(Guid id)
    {
        await _sampleRepository.DeleteAsync(id);
    }
}
