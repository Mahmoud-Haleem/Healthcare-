using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class Country : AuditedEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual List<State> States { get; set; }
    }
}
