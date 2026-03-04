using Volo.Abp.Modularity;

namespace Everbot.OnlineInterview;

public abstract class OnlineInterviewApplicationTestBase<TStartupModule> : OnlineInterviewTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
