using Volo.Abp.Modularity;

namespace AbpBookStore
{
    [DependsOn(
        typeof(AbpBookStoreApplicationModule),
        typeof(AbpBookStoreDomainTestModule)
        )]
    public class AbpBookStoreApplicationTestModule : AbpModule
    {

    }
}