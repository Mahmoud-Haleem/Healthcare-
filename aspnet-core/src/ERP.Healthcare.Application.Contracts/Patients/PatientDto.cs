using System;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Patients
{
    public class PatientDto : EntityDto<int>
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortDescription { get; set; }
    }
}