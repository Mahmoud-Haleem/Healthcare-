using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Healthcare.Patients
{
    public class UpdatePatientDto
    {
        [Required]
        [StringLength(PatientConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(PatientConsts.MaxShortDescriptionLength)]
        public string ShortDescription { get; set; }
    }
}