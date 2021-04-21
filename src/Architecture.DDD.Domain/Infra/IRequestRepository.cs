using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public interface IRequestRepository : IRepository<Request, Guid>
    {
        Task<Request> FindAsync(Guid id);
    }
}
