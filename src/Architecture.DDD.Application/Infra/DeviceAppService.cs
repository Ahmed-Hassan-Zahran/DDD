using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public class DeviceAppService : ApplicationService, IDeviceAppService
    {
        private readonly IRepository<Device, Guid> _deviceRepository;
        private readonly IDeviceRepository _deviceCustomRepository;

        private readonly DeviceManager _deviceManager;
        public DeviceAppService(IRepository<Device, Guid> deviceRepository, DeviceManager deviceManager, IDeviceRepository deviceCustomRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceManager = deviceManager;
            _deviceCustomRepository = deviceCustomRepository;
        }

        public async Task DeleteAsync(Guid Id)
        {
            await _deviceRepository.DeleteAsync(Id);
        }

        public async Task DeleteByTypeAsync(DeviceType type)
        {
            await _deviceCustomRepository.DeleteDeviceByType(type);
        }

        //public async Task DeleteByCodeAsync(int codeId)
        //{
        //    await _deviceRepository.DeleteAsync();
        //}

        public async Task<ListResultDto<DeviceDto>> GetListAsync()
        {
            var devices = await _deviceRepository.GetListAsync();
            var devicesToReturn = ObjectMapper.Map<List<Device>, List<DeviceDto>>(devices);
            return new ListResultDto<DeviceDto>(devicesToReturn);
        }

        public async Task<DeviceDto> GetAsync(Guid id)
        {
            var device = await _deviceRepository.GetAsync(id);
            return ObjectMapper.Map<Device, DeviceDto>(device);
        }

        public async Task<DeviceDto> CreateAsync(CreateDeviceDto input)
        {
            var device = await _deviceManager.CreateAsync(input.Code, input.Name, input.CurrentPrice, input.StockCount, input.UsedStockCount, input.ImageName, input.Type);
            return ObjectMapper.Map<Device, DeviceDto>(device);
        }

        public async Task<DeviceDto> UpdateAsync(UpdateDeviceDto input)
        {
            var device = await _deviceRepository.GetAsync(input.Id);
            if (device == null)
            {
                return null;
            }
            device.SetName(input.Name);
            device.SetImageName(input.ImageName);
            device.SetCurrentPrice(input.CurrentPrice);
            device.SetStockCount(input.StockCount);
            device.SetUsedStockCount(input.UsedStockCount);
            return ObjectMapper.Map<Device, DeviceDto>(device);
        }

    }
}
