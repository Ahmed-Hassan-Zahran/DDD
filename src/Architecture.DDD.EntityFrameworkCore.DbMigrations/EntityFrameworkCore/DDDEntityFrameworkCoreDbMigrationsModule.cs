using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Architecture.DDD.EntityFrameworkCore
{
    [DependsOn(
        typeof(DDDEntityFrameworkCoreModule)
        )]
    public class DDDEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DDDMigrationsDbContext>();
        }
    }
}
