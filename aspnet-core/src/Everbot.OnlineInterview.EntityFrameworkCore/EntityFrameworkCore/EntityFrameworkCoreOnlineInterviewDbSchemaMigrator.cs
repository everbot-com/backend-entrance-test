using System;
using System.Threading.Tasks;
using Everbot.OnlineInterview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Everbot.OnlineInterview.EntityFrameworkCore;

public class EntityFrameworkCoreOnlineInterviewDbSchemaMigrator
    : IOnlineInterviewDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOnlineInterviewDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the OnlineInterviewDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OnlineInterviewDbContext>()
            .Database
            .MigrateAsync();
    }
}
