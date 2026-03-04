using System;
using System.Threading.Tasks;
using Everbot.OnlineInterview.Controllers;
using Everbot.OnlineInterview.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例控制器
/// </summary>
[Authorize(OnlineInterviewPermissions.Samples.Default)]
public class SampleController : OnlineInterviewController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    /// <summary>
    /// 取得列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<ExtensiblePagedResultDto<SampleDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _sampleAppService.GetListAsync(input);
    }

    /// <summary>
    /// 取得項目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public Task<SampleDto> GetAsync(Guid id)
    {
        return _sampleAppService.GetAsync(id);
    }

    /// <summary>
    /// 新增項目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [Authorize(OnlineInterviewPermissions.Samples.Create)]
    [HttpPost]
    public Task<SampleDto> CreateAsync(SampleCreateInputDto input)
    {
        return _sampleAppService.CreateAsync(input);
    }

    /// <summary>
    /// 編輯項目
    /// </summary>
    [Authorize(OnlineInterviewPermissions.Samples.Update)]
    [HttpPut]
    public Task<SampleDto> UpdateAsync(Guid id, SampleUpdateInputDto input)
    {
        return _sampleAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 刪除項目
    /// </summary>
    [Authorize(OnlineInterviewPermissions.Samples.Delete)]
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return _sampleAppService.DeleteAsync(id);
    }
}
