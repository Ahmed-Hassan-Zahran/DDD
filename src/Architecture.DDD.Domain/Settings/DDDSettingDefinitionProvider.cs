using Volo.Abp.Settings;

namespace Architecture.DDD.Settings
{
    public class DDDSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DDDSettings.MySetting1));
        }
    }
}
