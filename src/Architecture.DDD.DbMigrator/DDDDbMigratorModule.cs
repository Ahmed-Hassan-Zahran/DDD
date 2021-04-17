using Architecture.DDD.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Architecture.DDD.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DDDEntityFrameworkCoreDbMigrationsModule),
        typeof(DDDApplicationContractsModule)
        )]
    public class DDDDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
