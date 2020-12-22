using AbpBookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpBookStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpBookStoreController : AbpController
    {
        protected AbpBookStoreController()
        {
            LocalizationResource = typeof(AbpBookStoreResource);
        }
    }
}