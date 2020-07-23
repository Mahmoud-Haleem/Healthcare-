using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class CreateUpdateAddressDto : EntityDto<int>
    {
        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(100)]
        public string DistrictName { get; set; }

        [Required]
        public int Postalcode { get; set; }

        [Required]
        public int BuildNumber { get; set; }

        [Required]
        public int ApartmentNumber { get; set; }

        [Required]
        public int CityId { get; set; }

    }
}
