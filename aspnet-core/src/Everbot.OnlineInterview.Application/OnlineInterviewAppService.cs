using System;
using System.Collections.Generic;
using System.Text;
using Everbot.OnlineInterview.Localization;
using Volo.Abp.Application.Services;

namespace Everbot.OnlineInterview;

/* Inherit your application services from this class.
 */
public abstract class OnlineInterviewAppService : ApplicationService
{
    protected OnlineInterviewAppService()
    {
        LocalizationResource = typeof(OnlineInterviewResource);
    }
}
