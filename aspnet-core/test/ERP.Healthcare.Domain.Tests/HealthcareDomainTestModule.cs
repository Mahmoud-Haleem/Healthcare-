using ERP.Healthcare.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ERP.Healthcare
{
    [DependsOn(
        typeof(HealthcareEntityFrameworkCoreTestModule)
        )]
    public class HealthcareDomainTestModule : AbpModule
    {

    }
}