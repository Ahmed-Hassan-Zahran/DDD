using Architecture.DDD.Eto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus;

namespace Architecture.DDD.Infra
{
    public class ActionFinishedOneHandler : ILocalEventHandler<ActionFinishedEto>,
          ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        public ActionFinishedOneHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task HandleEventAsync(ActionFinishedEto eventData)
        {
            await _emailSender.SendAsync("Ahmed75.Zahran01@gmail.com",     // target email address
                "Email subject",         // subject
                $"This is email body...{eventData.Description}");  // Email Body
        }
    }
}
