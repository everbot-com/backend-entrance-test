using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Everbot.OnlineInterview.Data;

/* This is used if database provider does't define
 * IOnlineInterviewDbSchemaMigrator implementation.
 */
public class NullOnlineInterviewDbSchemaMigrator : IOnlineInterviewDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
