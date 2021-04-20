using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.DDD.Infra
{
    public class RequestDto
    {
        public string Description { get; set; }

        public Department Department { get; set; }

        /// <summary>
        /// At least one week in the future
        /// </summary>
        public DateTime ExpectedDateTime { get; set; }

        /// <summary>
        /// -1 not set yet
        /// </summary>
        public int TotalActionsCount { get; set; }

        public List<ActionDto> Actions { get; set; }
    }
}
