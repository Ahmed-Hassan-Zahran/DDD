using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public interface IDeviceRepository : IRepository<Device, Guid>
    {
        Task DeleteDeviceByType(DeviceType type);
    }
}
