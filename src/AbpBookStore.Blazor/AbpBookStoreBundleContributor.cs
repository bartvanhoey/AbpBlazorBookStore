using Volo.Abp.Bundling;

namespace AbpBookStore.Blazor
{
    public class AbpBookStoreBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
