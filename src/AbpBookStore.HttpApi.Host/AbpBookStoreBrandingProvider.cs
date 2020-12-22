using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBookStore
{
    [Dependency(ReplaceServices = true)]
    public class AbpBookStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBookStore";
    }
}
