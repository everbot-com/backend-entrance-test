using Everbot.OnlineInterview.Samples;
using Xunit;

namespace Everbot.OnlineInterview.EntityFrameworkCore.Domains;

[Collection(OnlineInterviewTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OnlineInterviewEntityFrameworkCoreTestModule>
{

}
