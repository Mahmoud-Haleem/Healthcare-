using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class Membership : AuditedEntity<int>
    {
        public string Name { get; set; }

        public virtual Address Address { get; set; }
     
        public virtual List<DoctorMembership> DoctorMemberships { get; set; }
    }
}
