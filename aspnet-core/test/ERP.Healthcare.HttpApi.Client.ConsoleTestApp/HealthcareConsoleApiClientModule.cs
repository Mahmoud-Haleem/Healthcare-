using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ERP.Healthcare.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(HealthcareHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class HealthcareConsoleApiClientModule : AbpModule
    {
        
    }
}
