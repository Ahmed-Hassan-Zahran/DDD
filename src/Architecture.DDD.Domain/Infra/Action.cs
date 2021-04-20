using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Architecture.DDD.Infra
{
    public class Action: AuditedEntity<Guid>
    {
    }
}
