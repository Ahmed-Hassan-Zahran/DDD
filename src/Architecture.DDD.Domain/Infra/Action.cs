using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Architecture.DDD.Infra
{
    public class Action: AuditedEntity<Guid>
    {
        public string Description { get; set; }

        public ActionStatus Status { get; set; }

        public Location Location { get; set; }

        /// <summary>
        /// Business Rule: At least 3 days in the future
        /// Business Rule: At most Request execution limit
        /// If not set at creation time, Then it should be expected after 5 days by default
        /// </summary>
        public DateTime ExpectedDateTime { get; set; }

        protected Action()
        {

        }

        internal Action(string description, ActionStatus actionStatus = ActionStatus.UnAssigned, DateTime? expectedDateTime = null, string premises = "Main", string floor = "One")
        {
            Description = description;
            Status = actionStatus;
            Location = new Location(premises, floor);
            // Business Rule: All created actions should have expected date after 5 days
            if (expectedDateTime == null)
            {
                expectedDateTime = DateTime.Now.AddDays(5);
            }
            SetExpectedDateTime(expectedDateTime.Value);
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
