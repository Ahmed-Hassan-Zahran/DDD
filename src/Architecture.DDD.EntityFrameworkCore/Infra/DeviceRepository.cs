using Architecture.DDD.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Architecture.DDD.Infra
{
    public class DeviceRepository : EfCoreRepository<DDDDbContext, Device, Guid>, IDeviceRepository
    {
        public DeviceRepository(IDbContextProvider<DDDDbContext> dbContextProvider): base(dbContextProvider)
        {

        }

        public Task<Device> FindAsync(Guid id, string name)
        {
            return base.FindAsync(x => x.Id == id && x.Name == name);
        }

        public async Task<Device> FindByNameAsync(string name)
        {
            return await base.FindAsync(device => device.Name == name);
        }

        public async Task<List<Device>> GetUnTouchedDevicesAsync()
        {
            var daysAgo180 = DateTime.Now.Subtract(TimeSpan.FromDays(180));

            var dbSet = await GetDbSetAsync();
            return dbSet.Where(d => d.LastModificationTime < daysAgo180 ).ToList();
        }

        public async Task DeleteDeviceByType(DeviceType type)
        {
            var dbContext = await GetDbContextAsync();
            await dbContext.Database.ExecuteSqlRawAsync(
                $"DELETE FROM Books WHERE Type = {(int)type}"
            );
        }
    }
}
