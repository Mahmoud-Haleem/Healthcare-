using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class DoctorMembership : AuditedEntity<int>
    {
        public virtual Doctor Doctor { get; set; }

        public virtual Membership Membership { get; set; }
        
        public virtual DoctorShift DoctorShift { get; set; }
    }
}
