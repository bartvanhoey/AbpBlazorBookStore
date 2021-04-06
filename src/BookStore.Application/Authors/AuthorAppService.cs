using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Authors;
using BookStore.Domain.Authors;
using Volo.Abp.Application.Dtos;

namespace BookStore.Application.Authors
{
  // [Authorize(BookStorePermissions.Author.Default)] 
  public class AuthorAppService : BookStoreAppService, IAuthorAppService
  {
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorManager _authorManager;

    public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
    {
      _authorManager = authorManager;
      _authorRepository = authorRepository;

    }

    public Task<AuthorDto> CreateAsync(CreateAuthorDto input)
    {
      throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<AuthorDto> GetAsync(Guid id)
    {
      var author = await _authorRepository.GetAsync(id);
      return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Author.Name);
        }

        var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);
        
        // var totalCount = input.Filter == null ? await _authorRepository.CountAsync() : _authorRepository.GetCountAsync

        throw new System.NotImplementedException();


    }

    public Task UpdateAsync(Guid id, UpdateAuthorDto input)
    {
      throw new NotImplementedException();
    }
  }
}