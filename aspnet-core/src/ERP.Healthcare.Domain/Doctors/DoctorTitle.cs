using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class DoctorTitle : AuditedEntity<int>
    {
        public string Name { get; set; }
    }
}
