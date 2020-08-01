using ERP.Healthcare.Doctors;
using ERP.Healthcare.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ERP.Healthcare
{
    public class DoctorDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<DoctorSpecialty, int> _doctorSpecialtyRepository;
        private readonly IRepository<DoctorTitle, int> _doctorTitleRepository;
        private readonly IRepository<Membership, int> _membershipRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly PatientManager _patientManager;
        private readonly IRepository<City, int> _cityRepository;

        public DoctorDataSeederContributor(IRepository<DoctorSpecialty, int> doctorSpecialtyRepository
            , IRepository<DoctorTitle, int> doctorTitleRepository
            , IRepository<Membership, int> membershipRepository
            , IPatientRepository patientRepository
            , PatientManager patientManager)
        {
            _doctorSpecialtyRepository = doctorSpecialtyRepository;
            _doctorTitleRepository = doctorTitleRepository;
            _membershipRepository = membershipRepository;
            _patientRepository = patientRepository;
            _patientManager = patientManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (!(await _doctorSpecialtyRepository.GetCountAsync() > 0))
            {
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "جلدية" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "اسنان" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "نفسي" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "اطفال" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "مخ-واعصاب" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "عظام-والطب-الرياضى" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "نساء-وولادة" }, autoSave: true);
                await _doctorSpecialtyRepository.InsertAsync(new DoctorSpecialty { Name = "انف-واذن-وحنجرة" }, autoSave: true);
            }

            if (!(await _doctorTitleRepository.GetCountAsync() > 0))
            {
                await _doctorTitleRepository.InsertAsync(new DoctorTitle { Name = "أستاذ" }, autoSave: true);
                await _doctorTitleRepository.InsertAsync(new DoctorTitle { Name = "أخصائي اول" }, autoSave: true);
                await _doctorTitleRepository.InsertAsync(new DoctorTitle { Name = "استشاري" }, autoSave: true);
                await _doctorTitleRepository.InsertAsync(new DoctorTitle { Name = "أخصائي" }, autoSave: true);
            }

            await _patientRepository.InsertAsync(
                await _patientManager.CreateAsync(
                    1,
                  "George Orwell",
                  DateTime.Now,
                  "Orwell produced literary criticism and poetry, "
              )
            );

            await _patientRepository.InsertAsync(
                await _patientManager.CreateAsync(
                    1,
                   "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter"
                )
            );

        }
    }
}
