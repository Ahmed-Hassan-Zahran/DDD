using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Architecture.DDD.Infra
{
    public interface IDeviceAppService : IApplicationService
    {
        Task DeleteAsync(Guid Id);
        Task<ListResultDto<DeviceDto>> GetListAsync();
    }
}
