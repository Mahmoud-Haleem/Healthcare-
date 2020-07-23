using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class LockupsDto : EntityDto
    {
        public List<CountryDto> Country { get; set; }
        public List<StateDto> State { get; set; }
        public List<CityDto> City { get; set; }
        public List<DoctorSpecialtyDto> DoctorSpecialty { get; set; }
        public List<DoctorTitleDto> DoctorTitle { get; set; }
    } 
}
