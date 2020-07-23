using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class CreateUpdateDoctorDto : EntityDto<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public GenderTypeEnum Gender { get; set; }

        public int AddressId { get; set; }

        public int DoctorSpecialtyId { get; set; }

        public int DoctorTitleId { get; set; }

        public CreateUpdateAddressDto Address { get; set; }
    }
}
