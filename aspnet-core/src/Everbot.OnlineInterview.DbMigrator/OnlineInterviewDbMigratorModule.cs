using Everbot.OnlineInterview.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Everbot.OnlineInterview.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OnlineInterviewEntityFrameworkCoreModule),
    typeof(OnlineInterviewApplicationContractsModule)
    )]
public class OnlineInterviewDbMigratorModule : AbpModule
{
}
