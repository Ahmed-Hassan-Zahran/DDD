using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Architecture.DDD.Infra
{
    public class TotalActionsCountExceededTheLimitException: BusinessException
    {
        public TotalActionsCountExceededTheLimitException(int ActionsCount): base("RAE:0000002", $"Total actions count exceeded the required numbers for the request {ActionsCount} already exists.")
        {

        }
    }
}
