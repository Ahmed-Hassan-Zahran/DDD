using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Architecture.DDD.Infra
{
    public class DeviceManager : DomainService
    {
        private readonly IRepository<Device, Guid> _deviceRepository;
        public DeviceManager(IRepository<Device, Guid> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Device> CreateAsync([NotNull] string code, [NotNull] string name, float currentPrice, int stockCount, int usedStockCount, string imageName, DeviceType type)
        {
            var existingrDevice = await _deviceRepository.FirstOrDefaultAsync(p => p.Code == code);
            if (existingrDevice != null)
            {
                throw new DeviceCodeAlreadyExistsException(code);
            }

            return await _deviceRepository.InsertAsync(new Device(GuidGenerator.Create(), code, name, currentPrice, stockCount, usedStockCount, imageName, type));
        }
    }
}
