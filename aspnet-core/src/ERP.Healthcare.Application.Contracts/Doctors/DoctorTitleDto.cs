using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class DoctorTitleDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
