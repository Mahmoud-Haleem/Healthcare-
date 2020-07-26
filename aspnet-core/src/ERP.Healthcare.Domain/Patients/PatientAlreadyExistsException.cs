using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace ERP.Healthcare.Patients
{ 
    public class PatientAlreadyExistsException : BusinessException
    {
        public PatientAlreadyExistsException(string name)
            : base(HealthcareDomainErrorCodes.PatientAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
