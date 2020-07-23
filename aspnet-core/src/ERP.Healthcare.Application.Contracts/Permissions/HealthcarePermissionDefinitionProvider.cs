using ERP.Healthcare.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ERP.Healthcare.Permissions
{
    public class HealthcarePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HealthcarePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(HealthcarePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HealthcareResource>(name);
        }
    }
}
