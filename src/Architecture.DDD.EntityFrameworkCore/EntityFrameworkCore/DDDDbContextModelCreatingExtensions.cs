using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Architecture.DDD.EntityFrameworkCore
{
    public static class DDDDbContextModelCreatingExtensions
    {
        public static void ConfigureDDD(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DDDConsts.DbTablePrefix + "YourEntities", DDDConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}