using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class CityDto : EntityDto<int>
    {
        public string Name { get; set; }

        public StateDto State { get; set; }
    }
}
