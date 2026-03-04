using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Everbot.OnlineInterview.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Everbot.OnlineInterview.Samples;

/// <summary>
/// 範例倉儲
/// </summary>
public class EfCoreSampleRepository : EfCoreRepository<IOnlineInterviewDbContext, Sample, Guid>, ISampleRepository
{
    public EfCoreSampleRepository(IDbContextProvider<IOnlineInterviewDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    /// <summary>
    /// 取得清單
    /// </summary>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <param name="sorting"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public async Task<List<Sample>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    )
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet
            .Where(sample => string.IsNullOrWhiteSpace(filter) || sample.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
