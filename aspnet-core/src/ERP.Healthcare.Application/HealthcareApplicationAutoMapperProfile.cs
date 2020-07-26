using AutoMapper;
using ERP.Healthcare.Doctors;
using ERP.Healthcare.Patients;
using Volo.Abp.AutoMapper;

namespace ERP.Healthcare
{
    public class HealthcareApplicationAutoMapperProfile : Profile
    {
        public HealthcareApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<City, CityDto>();

            CreateMap<Address, AddressDto>();

            CreateMap<DoctorSpecialty, DoctorSpecialtyDto>();

            CreateMap<DoctorTitle, DoctorTitleDto>();

            CreateMap<Doctor, DoctorDto>()
                .ForMember(s => s.DoctorSpecialtyDto, opt => opt.MapFrom(src => src.DoctorSpecialty))
                .ForMember(s => s.DoctorTitleDto, opt => opt.MapFrom(src => src.DoctorTitle))
                .ForMember(s => s.AddressDto, opt => opt.MapFrom(src => src.Address));

            CreateMap<CreateUpdateDoctorDto, Doctor>();
            CreateMap<CreateUpdateAddressDto, Address>();
            CreateMap<CreateUpdateDoctorSpecialtyDto, DoctorSpecialty>();
            CreateMap<CreateUpdateDoctorTitleDto, DoctorTitle>();

            CreateMap<Patient, PatientDto>();
        }
    }
}
