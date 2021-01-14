using AbpBookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBookStore.Permissions
{
  public class AbpBookStorePermissionDefinitionProvider : PermissionDefinitionProvider
  {
    public override void Define(IPermissionDefinitionContext context)
    {
      var bookStoreGroup = context.AddGroup(AbpBookStorePermissions.GroupName);

      var booksPermission = bookStoreGroup.AddPermission(AbpBookStorePermissions.Book.Default, L("Permission:Book"));
      booksPermission.AddChild(AbpBookStorePermissions.Book.Create, L("Permission:Book:Create"));
      booksPermission.AddChild(AbpBookStorePermissions.Book.Update, L("Permission:Book:Update"));
      booksPermission.AddChild(AbpBookStorePermissions.Book.Delete, L("Permission:Book:Delete"));

      var authorsPermission = bookStoreGroup.AddPermission(AbpBookStorePermissions.Author.Default, L("Permission:Author"));
      authorsPermission.AddChild(AbpBookStorePermissions.Author.Create, L("Permission:Author:Create"));
      authorsPermission.AddChild(AbpBookStorePermissions.Author.Update, L("Permission:Author:Update"));
      authorsPermission.AddChild(AbpBookStorePermissions.Author.Delete, L("Permission:Author:Delete"));
    }

    private static LocalizableString L(string name)
    {
      return LocalizableString.Create<AbpBookStoreResource>(name);
    }
  }
}
