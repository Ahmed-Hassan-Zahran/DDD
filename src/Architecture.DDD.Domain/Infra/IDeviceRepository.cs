﻿using System;
using Volo.Abp.Domain.Repositories;

namespace Architecture.DDD.Infra
{
    public interface IDeviceRepository : IRepository<Device, Guid>
    {

    }
}
