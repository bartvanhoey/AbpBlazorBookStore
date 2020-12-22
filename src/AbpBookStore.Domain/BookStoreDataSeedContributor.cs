using System;
using System.Threading.Tasks;
using AbpBookStore.Domain.Books;
using AbpBookStore.Domain.Shared.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpBookStore.Domain
{
  public class BookStoreDataSeedContributor : IDataSeedContributor,  ITransientDependency
  {
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookStoreDataSeedContributor(IRepository<Book, Guid> bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
      if (await _bookRepository.GetCountAsync() <= 0)
      {
        var bookOrwell = new Book
        {
          Name = "1984",
          Type = BookType.Dystopia,
          PublishDate = new DateTime(1949, 6, 8),
          Price = 19.84f
        };
        await _bookRepository.InsertAsync(bookOrwell, autoSave: true);

        var bookDouglas = new Book
        {
          Name = "The Hitchhiker's Guide to the Galaxy",
          Type = BookType.ScienceFiction,
          PublishDate = new DateTime(1995, 9, 27),
          Price = 42.0f
        };
        await _bookRepository.InsertAsync(bookDouglas, autoSave: true);
      }


    }
  }
}