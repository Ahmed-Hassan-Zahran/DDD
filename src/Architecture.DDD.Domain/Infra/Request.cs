using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Architecture.DDD.Infra
{
    public class Request: AuditedAggregateRoot<Guid>
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
        public virtual int TotalActions { get; protected set; }
        public virtual int TotalActionsFinished { get; protected set; }

        public Request()
        {

        }

        public Request(string description, Department department, DateTime expectedDateTime, int totalActions, int totalActionsFinished)
        {
            Description = description;
            Department = department;
            SetExpectedDateTime(expectedDateTime);
            SetTotalActions(totalActions);
            SetTotalActionsFinished(totalActionsFinished);
        }

        public Request SetExpectedDateTime(DateTime expectedDateTime)
        {
            var daysAfter7 = DateTime.Now.AddDays(RequestConsts.MinimumExpectedExecutionDays);
            if (expectedDateTime < daysAfter7)
            {
                throw new ArgumentException($"Request expected date should be at least {RequestConsts.MinimumExpectedExecutionDays} days in the future");
            }
            ExpectedDateTime = expectedDateTime;
            return this;
        }

        public Request SetTotalActions(int totalActions)
        {
            if(totalActions < -1)
            {
                throw new ArgumentException($"Request total actions should be greater than -1");
            }
            TotalActions = totalActions;
            return this;
        }

        public Request SetTotalActionsFinished(int totalActionsFinished)
        {
            if (TotalActionsFinished < 0 || totalActionsFinished > TotalActions)
            {
                throw new ArgumentException($"Request total actions finished should be zero or less than or equal {TotalActions}");
            }
            TotalActionsFinished = totalActionsFinished;
            return this;
        }
    }
}
