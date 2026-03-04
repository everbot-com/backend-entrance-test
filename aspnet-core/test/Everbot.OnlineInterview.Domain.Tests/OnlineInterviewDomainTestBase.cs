using Volo.Abp.Modularity;

namespace Everbot.OnlineInterview;

/* Inherit from this class for your domain layer tests. */
public abstract class OnlineInterviewDomainTestBase<TStartupModule> : OnlineInterviewTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
