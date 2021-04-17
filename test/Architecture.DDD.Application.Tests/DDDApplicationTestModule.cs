using Volo.Abp.Modularity;

namespace Architecture.DDD
{
    [DependsOn(
        typeof(DDDApplicationModule),
        typeof(DDDDomainTestModule)
        )]
    public class DDDApplicationTestModule : AbpModule
    {

    }
}