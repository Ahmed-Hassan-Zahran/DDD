using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Architecture.DDD.Infra
{
    public class DeviceStockCountChangedEto : EtoBase
    {
        public Guid Id { get; }

        public int OldCount { get; set; }

        public int CurrentCount { get; set; }

        private DeviceStockCountChangedEto()
        {
            //Default constructor is needed for deserialization.
        }

        public DeviceStockCountChangedEto(Guid id, int oldCount, int currentCount)
        {
            Id = id;
            OldCount = oldCount;
            CurrentCount = currentCount;
        }
    }
}
