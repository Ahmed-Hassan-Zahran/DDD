using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public class RequestAppService : ApplicationService
    {
        private readonly IRepository<Request, Guid> _requestRepository;
        public RequestAppService(IRepository<Request, Guid> requestRepository)
        {
            _requestRepository = requestRepository;
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
    }
}
