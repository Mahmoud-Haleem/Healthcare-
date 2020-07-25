using ERP.Healthcare.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ERP.Healthcare.Permissions
{
    public class HealthcarePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //Define your own permissions here. Example:
            //myGroup.AddPermission(HealthcarePermissions.MyPermission1, L("Permission:MyPermission1"));

            var bookStoreGroup = context.AddGroup(HealthcarePermissions.GroupName, L("Permission:Healthcare"));

            var booksPermission = bookStoreGroup.AddPermission(HealthcarePermissions.Doctors.Default, L("Permission:Doctors"));
            booksPermission.AddChild(HealthcarePermissions.Doctors.Create, L("Permission:Doctors.Create"));
            booksPermission.AddChild(HealthcarePermissions.Doctors.Edit, L("Permission:Doctors.Edit"));
            booksPermission.AddChild(HealthcarePermissions.Doctors.Delete, L("Permission:Doctors.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HealthcareResource>(name);
        }
    }
}
