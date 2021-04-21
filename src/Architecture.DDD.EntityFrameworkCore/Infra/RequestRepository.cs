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
    public class RequestRepository : EfCoreRepository<DDDDbContext, Request, Guid>, IRequestRepository
    {
        public RequestRepository(IDbContextProvider<DDDDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<Request> FindAsync(Guid id)
        {
            var request = (await GetDbSetAsync()).Include(a => a.Actions).FirstOrDefault(r => r.Id == id);
            return request;
        }
    }
}
