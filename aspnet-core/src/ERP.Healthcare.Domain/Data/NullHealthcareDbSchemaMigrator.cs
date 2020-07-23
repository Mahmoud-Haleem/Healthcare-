using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ERP.Healthcare.Data
{
    /* This is used if database provider does't define
     * IHealthcareDbSchemaMigrator implementation.
     */
    public class NullHealthcareDbSchemaMigrator : IHealthcareDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}