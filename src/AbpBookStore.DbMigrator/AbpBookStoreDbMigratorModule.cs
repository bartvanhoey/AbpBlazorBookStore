using AbpBookStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpBookStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpBookStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpBookStoreApplicationContractsModule)
        )]
    public class AbpBookStoreDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
