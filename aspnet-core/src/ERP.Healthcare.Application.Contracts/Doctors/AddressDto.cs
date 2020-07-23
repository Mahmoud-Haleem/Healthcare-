using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class AddressDto : EntityDto<int>
    {
        public string StreetName { get; set; }

        public string DistrictName { get; set; }

        public int Postalcode { get; set; }

        public int BuildNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public int CityId { get; set; }

        public CityDto City { get; set; }
    }
}
