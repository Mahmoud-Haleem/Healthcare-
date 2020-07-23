using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Doctors
{
    public class DoctorSpecialtyDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
