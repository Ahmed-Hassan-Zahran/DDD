using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Architecture.DDD.Data;
using Volo.Abp.DependencyInjection;

namespace Architecture.DDD.EntityFrameworkCore
{
    public class EntityFrameworkCoreDDDDbSchemaMigrator
        : IDDDDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDDDDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DDDMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DDDMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}