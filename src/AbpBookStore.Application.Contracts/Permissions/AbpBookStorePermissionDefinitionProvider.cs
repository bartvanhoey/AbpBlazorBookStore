using AbpBookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBookStore.Permissions
{
    public class AbpBookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpBookStorePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpBookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpBookStoreResource>(name);
        }
    }
}
