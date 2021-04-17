using Volo.Abp;

namespace Architecture.DDD.Infra
{
    public class DeviceCodeAlreadyExistsException : BusinessException
    {
        public DeviceCodeAlreadyExistsException(string code) : base("DCE:0000001", $"A device with code {code} already exists.")
        {

        }
    }
}
