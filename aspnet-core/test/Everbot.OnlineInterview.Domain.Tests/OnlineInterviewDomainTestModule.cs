using Volo.Abp.Modularity;

namespace Everbot.OnlineInterview;

[DependsOn(
    typeof(OnlineInterviewDomainModule),
    typeof(OnlineInterviewTestBaseModule)
)]
public class OnlineInterviewDomainTestModule : AbpModule
{

}
