using Architecture.DDD.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Architecture.DDD.Permissions
{
    public class DDDPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DDDPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(DDDPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DDDResource>(name);
        }
    }
}
