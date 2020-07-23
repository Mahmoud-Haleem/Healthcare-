using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class State : AuditedEntity<int>
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
