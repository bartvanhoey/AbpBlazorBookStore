using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBookStore.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpBookStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBookStore";
    }
}
