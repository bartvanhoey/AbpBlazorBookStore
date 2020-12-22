using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpBookStore.Data
{
    /* This is used if database provider does't define
     * IAbpBookStoreDbSchemaMigrator implementation.
     */
    public class NullAbpBookStoreDbSchemaMigrator : IAbpBookStoreDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}