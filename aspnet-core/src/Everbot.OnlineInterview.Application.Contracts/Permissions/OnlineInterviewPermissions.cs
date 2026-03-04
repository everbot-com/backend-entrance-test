namespace Everbot.OnlineInterview.Permissions;

public static class OnlineInterviewPermissions
{
    public const string GroupName = "OnlineInterview";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Samples
    {
        public const string Default = GroupName + ".Samples";

        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Messages
    {
        public const string Default = GroupName + ".Messages";

        public const string Send = Default + ".Send";
    }
}
