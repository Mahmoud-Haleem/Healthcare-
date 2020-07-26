using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ERP.Healthcare.Patients
{
    public interface IPatientAppService : IApplicationService
    {
        Task<PatientDto> GetAsync(int id);

        Task<PagedResultDto<PatientDto>> GetListAsync(GetPatientListDto input);

        Task<PatientDto> CreateAsync(CreatePatientDto input);

        Task UpdateAsync(int id, UpdatePatientDto input);

        Task DeleteAsync(int id);
    }
}
