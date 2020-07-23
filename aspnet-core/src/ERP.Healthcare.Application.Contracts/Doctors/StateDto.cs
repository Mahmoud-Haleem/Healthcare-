using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class StateDto : EntityDto<int>
    {
        public string Name { get; set; }

        public CountryDto Country { get; set; }

    }
}
