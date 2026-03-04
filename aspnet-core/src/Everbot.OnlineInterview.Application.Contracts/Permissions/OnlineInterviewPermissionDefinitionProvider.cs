using Everbot.OnlineInterview.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Everbot.OnlineInterview.Permissions;

public class OnlineInterviewPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OnlineInterviewPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(OnlineInterviewPermissions.MyPermission1, L("Permission:MyPermission1"));

        var samplePermission = myGroup.AddPermission(OnlineInterviewPermissions.GroupName);
        samplePermission.AddChild(OnlineInterviewPermissions.Samples.Default);
        samplePermission.AddChild(OnlineInterviewPermissions.Samples.Create);
        samplePermission.AddChild(OnlineInterviewPermissions.Samples.Update);
        samplePermission.AddChild(OnlineInterviewPermissions.Samples.Delete);

        var messagePermission = myGroup.AddPermission(OnlineInterviewPermissions.Messages.Default);
        messagePermission.AddChild(OnlineInterviewPermissions.Messages.Send);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OnlineInterviewResource>(name);
    }
}
