using Everbot.OnlineInterview.Samples;
using Xunit;

namespace Everbot.OnlineInterview.EntityFrameworkCore.Applications;

[Collection(OnlineInterviewTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OnlineInterviewEntityFrameworkCoreTestModule>
{

}
