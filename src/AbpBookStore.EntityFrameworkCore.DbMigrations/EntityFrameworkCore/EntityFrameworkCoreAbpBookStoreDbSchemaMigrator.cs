using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpBookStore.Data;
using Volo.Abp.DependencyInjection;

namespace AbpBookStore.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpBookStoreDbSchemaMigrator
        : IAbpBookStoreDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpBookStoreDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpBookStoreMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpBookStoreMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}