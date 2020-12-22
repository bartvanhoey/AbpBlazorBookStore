using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AbpBookStore.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpBookStore.EntityFrameworkCore.Authors
{
  public class EfCoreAuthorRepository : EfCoreRepository<AbpBookStoreDbContext, Author, Guid>, IAuthorRepository
  {
    public EfCoreAuthorRepository(IDbContextProvider<AbpBookStoreDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Author> FindByNameAsync(string name)
    {
        
        return await DbSet.FirstOrDefaultAsync(author => author.Name == name);

    }

    public async Task<List<Author>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
       return await DbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), author => author.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
  }
}