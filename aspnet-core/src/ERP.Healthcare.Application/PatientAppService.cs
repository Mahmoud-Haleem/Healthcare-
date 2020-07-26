using ERP.Healthcare.Patients;
using ERP.Healthcare.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare
{
    [Authorize(HealthcarePermissions.Patients.Default)]
    public class PatientAppService : HealthcareAppService, IPatientAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly PatientManager _patientManager;

        public PatientAppService(
            IPatientRepository patientRepository,
            PatientManager patientManager)
        {
            _patientRepository = patientRepository;
            _patientManager = patientManager;
        }

        [Authorize(HealthcarePermissions.Patients.Create)]
        public async Task<PatientDto> CreateAsync(CreatePatientDto input)
        {
            var patient = await _patientManager.CreateAsync(input.Name, input.BirthDate, input.ShortDescription);

            await _patientRepository.InsertAsync(patient);

            return ObjectMapper.Map<Patient, PatientDto>(patient);
        }

        [Authorize(HealthcarePermissions.Patients.Delete)]
        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }

        public async Task<PatientDto> GetAsync(int id)
        {
            var patient = await _patientRepository.GetAsync(id);
            return ObjectMapper.Map<Patient, PatientDto>(patient);
        }

        public async Task<PagedResultDto<PatientDto>> GetListAsync(GetPatientListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Patient.Name);
            }

            var patients = await _patientRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            int totalCount = 0;
            
            if (!input.Filter.IsNullOrWhiteSpace())
            {
                var countQuery = _patientRepository.Where(p => p.Name.Contains(input.Filter));
                totalCount = await AsyncExecuter.CountAsync(countQuery);
            }

            return new PagedResultDto<PatientDto>(
                totalCount,
                ObjectMapper.Map<List<Patient>, List<PatientDto>>(patients)
            );
        }

        [Authorize(HealthcarePermissions.Patients.Edit)]
        public async Task UpdateAsync(int id, UpdatePatientDto input)
        {
            Patient patient = await _patientRepository.GetAsync(id);

            if (patient.Name != input.Name)
            {
                await _patientManager.ChangeNameAsync(patient, input.Name);
            }

            patient.BirthDate = input.BirthDate;
            patient.ShortDescription = input.ShortDescription;

            await _patientRepository.UpdateAsync(patient);    
        }
    }
}
