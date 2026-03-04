using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例倉儲介面
/// </summary>
public interface ISampleRepository : IRepository<Sample, Guid>
{
    /// <summary>
    /// 取得清單
    /// </summary>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <param name="sorting"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<List<Sample>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );
}
