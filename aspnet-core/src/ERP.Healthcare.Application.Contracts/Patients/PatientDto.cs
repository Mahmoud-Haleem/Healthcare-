using System;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Patients
{
    public class PatientDto : EntityDto<int>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortDescription { get; set; }
    }
}