using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Architecture.DDD.Infra
{
    public class Device : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// A unique value for this Device.
        /// DeviceManager ensures the uniqueness of it.
        /// It can not be changed after creation of the Device.
        /// </summary>
        [NotNull]
        public string Code { get; private set; }

        [NotNull]
        //[StringLength(DeviceConsts.MaxNameLength)]
        public string Name { get; private set; }

        public float CurrentPrice { get; private set; }

        public int StockCount { get; private set; }

        public int UsedStockCount { get; private set; }

        public string ImageName { get; private set; }

        public DeviceType Type { get; set; }

        private Device()
        {
            //Default constructor is needed for ORMs.
        }

        internal Device(
            Guid id,
            [NotNull] string code,
            [NotNull] string name,
            float currentPrice = 0.0f,
            int stockCount = 0,
            int usedStockCount = 0,
            string imageName = null,
            DeviceType type = DeviceType.Undefined)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length >= DeviceConsts.MaxCodeLength)
            {
                throw new ArgumentException($"Device code can not be longer than {DeviceConsts.MaxCodeLength}");
            }

            Id = id;
            Code = code;
            SetName(Check.NotNullOrWhiteSpace(name, nameof(name)));
            SetCurrentPrice(currentPrice);
            SetImageName(imageName);
            SetStockCountInternal(stockCount, triggerEvent: false);
            SetUsedStockCountInternal(usedStockCount, triggerEvent: false);
            Type = type;
        }

        public Device SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= DeviceConsts.MaxNameLength)
            {
                throw new ArgumentException($"Device name can not be longer than {DeviceConsts.MaxNameLength}");
            }

            Name = name;
            return this;
        }

        public Device SetImageName([CanBeNull] string imageName)
        {
            if (imageName == null)
            {
                return this;
            }

            if (imageName.Length >= DeviceConsts.MaxImageNameLength)
            {
                throw new ArgumentException($"Device image name can not be longer than {DeviceConsts.MaxImageNameLength}");
            }

            ImageName = imageName;
            return this;
        }

        public Device SetCurrentPrice(float currentPrice)
        {
            if (currentPrice < 0.0f)
            {
                throw new ArgumentException($"{nameof(currentPrice)} can not be less than 0.0!");
            }

            CurrentPrice = currentPrice;
            return this;
        }

        public Device SetStockCount(int stockCount)
        {
            return SetStockCountInternal(stockCount);
        }

        private Device SetStockCountInternal(int stockCount, bool triggerEvent = true)
        {
            if (StockCount < 0)
            {
                throw new ArgumentException($"{nameof(stockCount)} can not be less than 0!");
            }

            if (StockCount == stockCount)
            {
                return this;
            }

            // Next

            StockCount = stockCount;
            return this;
        }

        public Device SetUsedStockCount(int usedStockCount)
        {
            return SetUsedStockCountInternal(usedStockCount);
        }

        private Device SetUsedStockCountInternal(int usedStockCount, bool triggerEvent = true)
        {
            if (usedStockCount < 0)
            {
                throw new ArgumentException($"{nameof(usedStockCount)} can not be less than 0!");
            }

            if (UsedStockCount == usedStockCount)
            {
                return this;
            }

            // Next 1

            UsedStockCount = usedStockCount;
            return this;
        }
    }
}
