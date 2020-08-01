using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ERP.Healthcare.Patients
{ 
    public class Patient : FullAuditedAggregateRoot<int>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string ShortDescription { get; set; }
        public int DoctorId { get; set; }

        private Patient()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Patient(
            [NotNull] int doctorId,
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortDescription = null)
            : base()
        {
            SetName(name);
            BirthDate = birthDate;
            ShortDescription = shortDescription;
            DoctorId = doctorId;
        }

        internal Patient ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: PatientConsts.MaxNameLength
            );
        }
    }
}
