using System.Threading.Tasks;

namespace Architecture.DDD.Data
{
    public interface IDDDDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
