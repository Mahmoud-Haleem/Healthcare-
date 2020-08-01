using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ERP.Healthcare.Patients
{
    public class PatientManager : DomainService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientManager(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> CreateAsync(
            [NotNull] int doctorId,
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingPatient = await _patientRepository.FindByNameAsync(name);
            if (existingPatient != null)
            {
                throw new PatientAlreadyExistsException(name);
            }

            return new Patient(
                doctorId,
                name,
                birthDate,
                shortBio
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Patient patient,
            [NotNull] string newName)
        {
            Check.NotNull(patient, nameof(patient));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingPatient = await _patientRepository.FindByNameAsync(newName);
            if (existingPatient != null && existingPatient.Id != patient.Id)
            {
                throw new PatientAlreadyExistsException(newName);
            }

            patient.ChangeName(newName);
        }
    }
}
