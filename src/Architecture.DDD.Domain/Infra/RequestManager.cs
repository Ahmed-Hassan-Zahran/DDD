using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Architecture.DDD.Infra
{
    public class RequestManager : DomainService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        public RequestManager(IRepository<Request, Guid> requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Request> ChangeActionStatus(Guid requestId, Guid actionId, ActionStatus actionStatus)
        {
            var request = await _requestRepository.FindAsync(requestId);
            //request.Ch
            return request;
        }
    }
}
