using Volo.Abp.Application.Dtos;

namespace ERP.Healthcare.Patients
{
    public class DoctorLookupDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
