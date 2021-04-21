using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Architecture.DDD.Infra
{
    public class Action: AuditedEntity<Guid>
    {
        public string Description { get; set; }

        public ActionStatus Status { get; set; }

        /// <summary>
        /// Business Rule: At least 3 days in the future
        /// Business Rule: At most Request execution limit - 1
        /// </summary>
        public DateTime ExpectedDateTime { get; set; }

        protected Action()
        {

        }

        internal Action(string description, ActionStatus actionStatus = ActionStatus.UnAssigned)
        {
            Description = description;
            Status = actionStatus;
            // Business Rule: All created actions should have expected date after 5 days
            ExpectedDateTime = DateTime.Now.AddDays(5);
        }

        internal Action SetExpectedDateTime(DateTime expectedDateTime)
        {
            var daysAfterMinimum = DateTime.Now.AddDays(ActionsConsts.MinimumExpectedExecutionDays);
            var daysAfterMaximum = DateTime.Now.AddDays(RequestConsts.MinimumExpectedExecutionDays - 1);
            if (expectedDateTime < daysAfterMinimum && expectedDateTime > daysAfterMaximum)
            {
                throw new ActionDaysNotInRangeException(ActionsConsts.MinimumExpectedExecutionDays, RequestConsts.MinimumExpectedExecutionDays - 1);
            }
            ExpectedDateTime = expectedDateTime;
            return this;
        }

        internal Action ChangeStatus(ActionStatus status)
        {
            Status = status;
            return this;
        }

    }
}
