using Volo.Abp;

namespace Architecture.DDD.Infra
{
    public class ActionDaysNotInRangeException : BusinessException
    {
        public ActionDaysNotInRangeException(int min, int max) : base("Action:0000003", $"Action Expected finished days should not be before {min} days and not after {max} days.")
        {
        }
    }
}
