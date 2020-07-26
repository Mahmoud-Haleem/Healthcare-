using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ERP.Healthcare.Patients
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
        Task<Patient> FindByNameAsync(string name);

        Task<List<Patient>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
