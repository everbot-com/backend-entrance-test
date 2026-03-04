using Everbot.OnlineInterview.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Everbot.OnlineInterview;

[Dependency(ReplaceServices = true)]
public class OnlineInterviewBrandingProvider : DefaultBrandingProvider
{
    private readonly IStringLocalizer<OnlineInterviewResource> _localizer;

    public OnlineInterviewBrandingProvider(IStringLocalizer<OnlineInterviewResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
