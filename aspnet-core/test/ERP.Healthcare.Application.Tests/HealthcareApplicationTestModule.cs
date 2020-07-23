using Volo.Abp.Modularity;

namespace ERP.Healthcare
{
    [DependsOn(
        typeof(HealthcareApplicationModule),
        typeof(HealthcareDomainTestModule)
        )]
    public class HealthcareApplicationTestModule : AbpModule
    {

    }
}