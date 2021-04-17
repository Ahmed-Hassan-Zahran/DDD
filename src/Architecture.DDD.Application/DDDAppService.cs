using System;
using System.Collections.Generic;
using System.Text;
using Architecture.DDD.Localization;
using Volo.Abp.Application.Services;

namespace Architecture.DDD
{
    /* Inherit your application services from this class.
     */
    public abstract class DDDAppService : ApplicationService
    {
        protected DDDAppService()
        {
            LocalizationResource = typeof(DDDResource);
        }
    }
}
