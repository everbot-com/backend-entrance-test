using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例服務介面
/// </summary>
public interface ISampleAppService : IApplicationService
{
    /// <summary>
    /// 取得列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<ExtensiblePagedResultDto<SampleDto>> GetListAsync(PagedAndSortedResultRequestDto input);

    /// <summary>
    /// 取得項目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SampleDto> GetAsync(Guid id);

    /// <summary>
    /// 新增項目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SampleDto> CreateAsync(SampleCreateInputDto input);

    /// <summary>
    /// 編輯項目
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<SampleDto> UpdateAsync(Guid id, SampleUpdateInputDto input);

    /// <summary>
    /// 刪除項目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id);
}
