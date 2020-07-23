using System.Threading.Tasks;

namespace ERP.Healthcare.Data
{
    public interface IHealthcareDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
