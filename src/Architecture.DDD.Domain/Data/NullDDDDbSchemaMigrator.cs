using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Architecture.DDD.Data
{
    /* This is used if database provider does't define
     * IDDDDbSchemaMigrator implementation.
     */
    public class NullDDDDbSchemaMigrator : IDDDDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}