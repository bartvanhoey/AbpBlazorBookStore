using System;
using AbpBookStore.Application.Contracts.Books;
using AbpBookStore.Domain.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpBookStore.Application.Books
{
  public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto>, IBookAppService
  {
    public BookAppService(IRepository<Book, Guid> repository) : base(repository)
    {
      // GetPolicyName = AbpBookStorePermissions.Book.Default;
      // GetListPolicyName = AbpBookStorePermissions.Book.Default;
      // CreatePolicyName = AbpBookStorePermissions.Book.Create;
      // UpdatePolicyName = AbpBookStorePermissions.Book.Update;
      // DeletePolicyName = AbpBookStorePermissions.Book.Delete;
    }
  }
}