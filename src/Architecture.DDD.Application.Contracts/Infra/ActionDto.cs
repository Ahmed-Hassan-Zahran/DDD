using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.DDD.Infra
{
    public class ActionDto
    {
        public string Description { get; set; }

        public ActionStatus Status { get; set; }

        public DateTime? ExpectedDateTime { get; set; }

        public string Premises { get; set; }
        public string Floor { get; set; }


    }
}
