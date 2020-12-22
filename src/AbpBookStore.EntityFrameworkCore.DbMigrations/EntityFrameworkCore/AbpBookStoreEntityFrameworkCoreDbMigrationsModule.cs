using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpBookStore.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpBookStoreEntityFrameworkCoreModule)
        )]
    public class AbpBookStoreEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBookStoreMigrationsDbContext>();
        }
    }
}
