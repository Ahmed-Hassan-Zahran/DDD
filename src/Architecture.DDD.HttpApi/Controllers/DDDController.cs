using Architecture.DDD.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Architecture.DDD.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DDDController : AbpController
    {
        protected DDDController()
        {
            LocalizationResource = typeof(DDDResource);
        }
    }
}