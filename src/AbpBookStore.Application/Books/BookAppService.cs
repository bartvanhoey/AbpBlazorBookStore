using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbpBookStore.Application.Contracts.Books;
using AbpBookStore.Domain.Authors;
using AbpBookStore.Domain.Books;
using AbpBookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;

namespace AbpBookStore.Application.Books
{
  public class BookAppService : CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto>, IBookAppService
  {
    private readonly IAuthorRepository _authorRepository;

    public BookAppService(IRepository<Book, Guid> repository, IAuthorRepository authorRepository) : base(repository)
    {
      GetPolicyName = AbpBookStorePermissions.Book.Default;
      GetListPolicyName = AbpBookStorePermissions.Book.Default;
      CreatePolicyName = AbpBookStorePermissions.Book.Create;
      UpdatePolicyName = AbpBookStorePermissions.Book.Update;
      DeletePolicyName = AbpBookStorePermissions.Book.Delete;
      _authorRepository = authorRepository;
    }


    public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
    {
      var authors = await _authorRepository.GetListAsync();
      return new ListResultDto<AuthorLookupDto>(ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors));
    }

    public override async Task<BookDto> GetAsync(Guid id)
    {
      await CheckGetPolicyAsync();

      var query = from book in Repository
                  join author in _authorRepository on book.AuthorId equals author.Id
                  where book.Id == id
                  select new { book, author };

      var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
      if (queryResult == null) throw new EntityNotFoundException();

      var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);
      bookDto.AuthorName = queryResult.author.Name;

      return bookDto;
    }

    public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {

      await CheckGetListPolicyAsync();

      var query = from book in Repository
                  join author in _authorRepository on book.AuthorId equals author.Id
                  orderby input.Sorting
                  select new { book, author };

      query = query.Skip(input.SkipCount).Take(input.MaxResultCount);

      var queryResult = await AsyncExecuter.ToListAsync(query);

      var bookDtos = queryResult.Select(x =>
      {
        var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
        bookDto.AuthorName = x.author.Name;
        return bookDto;
      }).ToList();

      var totalCount = await Repository.GetCountAsync();

      return new PagedResultDto<BookDto>(totalCount, bookDtos);
    }

    


  }
}