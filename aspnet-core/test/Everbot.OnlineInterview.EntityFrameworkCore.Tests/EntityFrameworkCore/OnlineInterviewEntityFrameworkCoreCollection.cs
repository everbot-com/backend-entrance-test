using Xunit;

namespace Everbot.OnlineInterview.EntityFrameworkCore;

[CollectionDefinition(OnlineInterviewTestConsts.CollectionDefinitionName)]
public class OnlineInterviewEntityFrameworkCoreCollection : ICollectionFixture<OnlineInterviewEntityFrameworkCoreFixture>
{

}
