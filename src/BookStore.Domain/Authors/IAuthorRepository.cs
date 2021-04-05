using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Domain.Authors
{
    public interface IAuthorRepository :  IRepository<Author, Guid>
    {
         Task<Author> FindByNameAsync(string name);
    }
}