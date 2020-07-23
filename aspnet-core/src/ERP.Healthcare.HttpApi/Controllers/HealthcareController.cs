using ERP.Healthcare.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ERP.Healthcare.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HealthcareController : AbpController
    {
        protected HealthcareController()
        {
            LocalizationResource = typeof(HealthcareResource);
        }
    }
}