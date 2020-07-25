namespace ERP.Healthcare.Permissions
{
    public static class HealthcarePermissions
    {
        public const string GroupName = "Healthcare";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class Doctors
        {
            public const string Default = GroupName + ".Doctors";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
}
}