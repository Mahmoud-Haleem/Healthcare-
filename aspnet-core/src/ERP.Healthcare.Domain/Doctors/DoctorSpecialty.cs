using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class DoctorSpecialty : AuditedEntity<int>
    {
        public string Name { get; set; }

    }
}
