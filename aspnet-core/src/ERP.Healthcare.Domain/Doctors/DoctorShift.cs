using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class DoctorShift : AuditedEntity<int>
    {
        public int Day { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }
}
