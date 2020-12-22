using System.Threading.Tasks;

namespace AbpBookStore.Data
{
    public interface IAbpBookStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
