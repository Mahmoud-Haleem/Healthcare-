using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ERP.Healthcare.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class HealthcareMigrationsDbContextFactory : IDesignTimeDbContextFactory<HealthcareMigrationsDbContext>
    {
        public HealthcareMigrationsDbContext CreateDbContext(string[] args)
        {
            HealthcareEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HealthcareMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HealthcareMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
