using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Doctors
{
    public class Address : AuditedEntity<int>
    {
        public string StreetName { get; set; }

        public string DistrictName { get; set; }

        public int Postalcode { get; set; }

        public int BuildNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
