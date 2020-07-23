using System;
using System.Collections.Generic;
using System.Text;
using ERP.Healthcare.Localization;
using Volo.Abp.Application.Services;

namespace ERP.Healthcare
{
    /* Inherit your application services from this class.
     */
    public abstract class HealthcareAppService : ApplicationService
    {
        protected HealthcareAppService()
        {
            LocalizationResource = typeof(HealthcareResource);
        }
    }
}
