using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class DoctorService : AuditedEntity<int>
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
