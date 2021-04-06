using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using BookStore.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore.Authors
{
  public class AuthorRepository : EfCoreRepository<BookStoreDbContext, Author, Guid>, IAuthorRepository
  {
  public AuthorRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
  {
  }

    public async Task<Author> FindByNameAsync(string name)
    {
      var dbSet = await GetDbSetAsync();
      return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<Author>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
      var dbSet = await GetDbSetAsync();
      return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
    }
  }
}