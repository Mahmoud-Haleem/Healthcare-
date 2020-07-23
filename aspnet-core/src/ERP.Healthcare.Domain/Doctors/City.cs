using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class City : AuditedEntity<int>
    {
        public string Name { get; set; }
        
        public virtual State State { get; set; }
    }
}
