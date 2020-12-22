using AbpBookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpBookStore
{
    [DependsOn(
        typeof(AbpBookStoreEntityFrameworkCoreTestModule)
        )]
    public class AbpBookStoreDomainTestModule : AbpModule
    {

    }
}