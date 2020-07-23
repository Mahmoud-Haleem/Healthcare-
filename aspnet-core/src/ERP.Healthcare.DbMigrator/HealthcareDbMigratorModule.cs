using ERP.Healthcare.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ERP.Healthcare.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HealthcareEntityFrameworkCoreDbMigrationsModule),
        typeof(HealthcareApplicationContractsModule)
        )]
    public class HealthcareDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
