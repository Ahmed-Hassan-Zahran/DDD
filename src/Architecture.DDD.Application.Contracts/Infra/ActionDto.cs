using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.DDD.Infra
{
    public class ActionDto
    {
        public string Description { get; set; }

        public ActionStatus Status { get; set; }

        /// <summary>
        /// Business Rule: At least 3 days in the future
        /// Business Rule: At most Request execution limit - 1
        /// </summary>
        public DateTime ExpectedDateTime { get; set; }
    }
}
