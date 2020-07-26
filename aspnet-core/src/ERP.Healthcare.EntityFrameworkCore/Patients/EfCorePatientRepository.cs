using ERP.Healthcare.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ERP.Healthcare.Patients
{
    public class EfCorePatientRepository
        : EfCoreRepository<HealthcareDbContext, Patient, int>,
            IPatientRepository
    {
        public EfCorePatientRepository(
            IDbContextProvider<HealthcareDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Patient> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(author => author.Name == name);
        }

        public async Task<List<Patient>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            return await DbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
