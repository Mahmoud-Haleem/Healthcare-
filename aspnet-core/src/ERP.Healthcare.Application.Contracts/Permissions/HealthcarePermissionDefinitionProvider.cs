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

            var healthcareGroup = context.AddGroup(HealthcarePermissions.GroupName, L("Permission:Healthcare"));

            var doctorsPermission = healthcareGroup.AddPermission(HealthcarePermissions.Doctors.Default, L("Permission:Doctors"));
            doctorsPermission.AddChild(HealthcarePermissions.Doctors.Create, L("Permission:Doctors.Create"));
            doctorsPermission.AddChild(HealthcarePermissions.Doctors.Edit, L("Permission:Doctors.Edit"));
            doctorsPermission.AddChild(HealthcarePermissions.Doctors.Delete, L("Permission:Doctors.Delete"));

            var patientPermission = healthcareGroup.AddPermission(HealthcarePermissions.Patients.Default, L("Permission:Patients"));
            patientPermission.AddChild(HealthcarePermissions.Patients.Create, L("Permission:Patients.Create"));
            patientPermission.AddChild(HealthcarePermissions.Patients.Edit, L("Permission:Patients.Edit"));
            patientPermission.AddChild(HealthcarePermissions.Patients.Delete, L("Permission:Patients.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HealthcareResource>(name);
        }
    }
}
