using Everbot.OnlineInterview.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Everbot.OnlineInterview.Controllers;

/* Inherit your controllers from this class.
 */
[RemoteService(Name = "OnlineInterview")]
[Route("api/v1/[controller]")]
[Authorize]
public abstract class OnlineInterviewController : AbpControllerBase
{
    protected OnlineInterviewController()
    {
        LocalizationResource = typeof(OnlineInterviewResource);
    }
}
