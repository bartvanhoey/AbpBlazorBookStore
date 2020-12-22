using AbpBookStore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpBookStore.Blazor
{
    public abstract class AbpBookStoreComponentBase : AbpComponentBase
    {
        protected AbpBookStoreComponentBase()
        {
            LocalizationResource = typeof(AbpBookStoreResource);
        }
    }
}
