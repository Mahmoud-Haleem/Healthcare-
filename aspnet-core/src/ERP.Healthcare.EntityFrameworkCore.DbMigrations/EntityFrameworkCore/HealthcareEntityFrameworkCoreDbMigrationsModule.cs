using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ERP.Healthcare.EntityFrameworkCore
{
    [DependsOn(
        typeof(HealthcareEntityFrameworkCoreModule)
        )]
    public class HealthcareEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HealthcareMigrationsDbContext>();
        }
    }
}
