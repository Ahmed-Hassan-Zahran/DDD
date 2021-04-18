using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.DDD.Infra
{
    public class CreateDeviceDto
    {
        public string Code { get; set; }

        [Required]
        [StringLength(DeviceConsts.MaxNameLength)]
        public string Name { get; set; }

        public float CurrentPrice { get; set; }

        public int StockCount { get; set; }

        public int UsedStockCount { get; set; }

        //[StringLength(DeviceConsts.MaxImageNameLength)]
        public string ImageName { get; set; }

        public DeviceType Type { get; set; }
    }
}
