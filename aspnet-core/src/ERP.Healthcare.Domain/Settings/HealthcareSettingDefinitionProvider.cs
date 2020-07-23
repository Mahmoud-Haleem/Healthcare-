using Volo.Abp.Settings;

namespace ERP.Healthcare.Settings
{
    public class HealthcareSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HealthcareSettings.MySetting1));
        }
    }
}
