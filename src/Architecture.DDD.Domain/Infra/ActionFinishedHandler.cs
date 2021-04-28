using Architecture.DDD.Eto;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus;

namespace Architecture.DDD.Infra
{
    public class ActionFinishedHandler : ILocalEventHandler<ActionFinishedEto>,
          ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        public ActionFinishedHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task HandleEventAsync(ActionFinishedEto eventData)
        {
            _emailSender.SendAsync("Ahmed75.Zahran01@gmail.com",     // target email address
                "Email subject",         // subject
                $"This is email body...{eventData.Description}");  // Email Body
            return Task.CompletedTask;
        }
    }
}
