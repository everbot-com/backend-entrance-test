using Volo.Abp.Modularity;

namespace Everbot.OnlineInterview;

[DependsOn(
    typeof(OnlineInterviewApplicationModule),
    typeof(OnlineInterviewDomainTestModule)
)]
public class OnlineInterviewApplicationTestModule : AbpModule
{

}
