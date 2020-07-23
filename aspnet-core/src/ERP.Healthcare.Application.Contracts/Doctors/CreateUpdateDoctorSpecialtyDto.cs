using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class CreateUpdateDoctorSpecialtyDto : EntityDto<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
