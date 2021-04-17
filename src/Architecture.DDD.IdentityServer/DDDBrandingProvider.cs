using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Architecture.DDD
{
    [Dependency(ReplaceServices = true)]
    public class DDDBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DDD";
    }
}
