using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class CountryDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
