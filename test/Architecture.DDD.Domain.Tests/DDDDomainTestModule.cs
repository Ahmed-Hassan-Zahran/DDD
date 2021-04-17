using Architecture.DDD.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Architecture.DDD
{
    [DependsOn(
        typeof(DDDEntityFrameworkCoreTestModule)
        )]
    public class DDDDomainTestModule : AbpModule
    {

    }
}