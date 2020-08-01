using ERP.Healthcare.Doctors;
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
using Volo.Abp.Domain.Repositories;

namespace ERP.Healthcare
{
    [Authorize(HealthcarePermissions.Patients.Default)]
    public class PatientAppService : HealthcareAppService, IPatientAppService
    {
        private readonly IRepository<Doctor, int> _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientManager _patientManager;

        public PatientAppService(
            IRepository<Doctor, int> doctorRepository,
            IPatientRepository patientRepository,
            PatientManager patientManager)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _patientManager = patientManager;
        }

        [Authorize(HealthcarePermissions.Patients.Create)]
        public async Task<PatientDto> CreateAsync(CreatePatientDto input)
        {
            var patient = await _patientManager.CreateAsync(input.DoctorId, input.Name, input.BirthDate, input.ShortDescription);

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

            var patientDto = ObjectMapper.Map<Patient, PatientDto>(patient);

            var doctor = await _doctorRepository.GetAsync(patientDto.DoctorId);
            patientDto.DoctorName = doctor.Name;

            return patientDto;
        }

        public async Task<ListResultDto<DoctorLookupDto>> GetDoctorLookupAsync()
        {
            var doctors = await _doctorRepository.GetListAsync();

            return new ListResultDto<DoctorLookupDto>(
                ObjectMapper.Map<List<Doctor>, List<DoctorLookupDto>>(doctors)
            );
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

            var patientsDtos = ObjectMapper.Map<List<Patient>, List<PatientDto>>(patients);

            var doctorDictionary = await GetDoctorDictionaryAsync(patients);

            patientsDtos.ForEach(patientDto => patientDto.DoctorName = doctorDictionary[patientDto.DoctorId].Name);

            var countQuery = _patientRepository.WhereIf(
                                    !input.Filter.IsNullOrWhiteSpace(), 
                                    p => p.Name.Contains(input.Filter));
            
            var totalCount = await AsyncExecuter.CountAsync(countQuery);

            return new PagedResultDto<PatientDto>(
                totalCount,
                patientsDtos
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

        private async Task<Dictionary<int, Doctor>> GetDoctorDictionaryAsync(List<Patient> patients)
        {
            var doctorIds = patients
                .Select(b => b.DoctorId)
                .Distinct()
                .ToArray();

            var doctors = await AsyncExecuter.ToListAsync(
                _doctorRepository.Where(a => doctorIds.Contains(a.Id))
            );

            return doctors.ToDictionary(x => x.Id, x => x);
        }
    }
}
