using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace ERP.Healthcare.Doctors
{
    public class DoctorDto : EntityDto<int> 
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public GenderTypeEnum Gender { get; set; }

        public int AddressId { get; set; }

        public int DoctorSpecialtyId { get; set; }

        public int DoctorTitleId { get; set; }

        public AddressDto AddressDto { get; set; }

        public DoctorSpecialtyDto DoctorSpecialtyDto { get; set; }

        public DoctorTitleDto DoctorTitleDto { get; set; }
    }
}
