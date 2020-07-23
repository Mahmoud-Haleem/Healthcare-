using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class Doctor : AuditedAggregateRoot<int>
    {
        public string Name { get; set; }
 
        public string Description { get; set; }
        
        public GenderTypeEnum Gender { get; set; }

        public int AddressId { get; set; }
        
        public int DoctorSpecialtyId { get; set; }
        
        public int DoctorTitleId { get; set; }
        
        public virtual Address Address { get; set; }

        public virtual DoctorSpecialty DoctorSpecialty { get; set; }
     
        public virtual DoctorTitle DoctorTitle { get; set; }

        public virtual List<DoctorMembership> DoctorMemberships { get; set; }
    }
}
