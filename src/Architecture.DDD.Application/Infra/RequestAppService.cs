using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public class RequestAppService : ApplicationService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        private readonly IRequestRepository _requestCustomRepository;

        private readonly RequestManager _requestManager;
        public RequestAppService(IRepository<Request, Guid> requestRepository, RequestManager requestManager, IRequestRepository requestCustomRepository)
        {
            _requestRepository = requestRepository;
            _requestManager = requestManager;
            _requestCustomRepository = requestCustomRepository;
        }

        public async Task<RequestDto> Create(CreateRequestDto input)
        {
            var request = new Request(input.Description, input.Department, input.ExpectedDateTime, input.TotalActionsCount);
            foreach (var a in input.Actions)
            {
                request.AddAction(a.Description);
            }

            var requestCreated = await _requestRepository.InsertAsync(request);
            return ObjectMapper.Map<Request, RequestDto>(requestCreated);
        }

        public async Task<RequestDto> ChangeActionStatus(Guid requestId, Guid actionId, ActionStatus actionStatus)
        {
            var request = await _requestCustomRepository.FindAsync(requestId);
            request.ChangeActionStatus(actionId,actionStatus);
            return ObjectMapper.Map<Request, RequestDto>(request);
        }

    }
}
