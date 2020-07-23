using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ERP.Healthcare.Data;
using Volo.Abp.DependencyInjection;

namespace ERP.Healthcare.EntityFrameworkCore
{
    public class EntityFrameworkCoreHealthcareDbSchemaMigrator
        : IHealthcareDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHealthcareDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HealthcareMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HealthcareMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}