using Architecture.DDD.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Architecture.DDD.Infra
{
    public class DeviceRepository : EfCoreRepository<DDDDbContext, Device, Guid>
    {
        public DeviceRepository(IDbContextProvider<DDDDbContext> dbContextProvider): base(dbContextProvider)
        {

        }

        public Task<Device> FindAsync(Guid id, string name)
        {
            return base.FindAsync(x => x.Id == id && x.Name == name);
        }
    }
}
