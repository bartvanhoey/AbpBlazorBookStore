

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpBookStore.Application.Contracts.Authors;
using AbpBookStore.Domain.Authors;
using AbpBookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace AbpBookStore.Application.Authors
{
  // [Authorize(AbpBookStorePermissions.Author.Default)] 
  public class AuthorAppService : AbpBookStoreAppService, IAuthorAppService
  {
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorManager _authorManager;

    public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
    {
      _authorRepository = authorRepository;
      _authorManager = authorManager;
    }


    [Authorize(AbpBookStorePermissions.Author.Create)]
    public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
    {
      var author = await _authorManager.CreateAsync(input.Name, input.BirthDate, input.ShortBio);

      await _authorRepository.InsertAsync(author, autoSave: false);
      return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task DeleteAsync(Guid id)
    {
      await _authorRepository.DeleteAsync(id, autoSave: false);

    }

    public async Task<AuthorDto> GetAsync(Guid id)
    {
      var author = await _authorRepository.GetAsync(id);
      return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
    {
      if (input.Sorting.IsNullOrWhiteSpace()) input.Sorting = nameof(Author.Name);

      var authors = await _authorRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);

      var query = _authorRepository.WhereIf(!input.Filter.IsNullOrWhiteSpace(), author => author.Name.Contains(input.Filter));
      var totalCount = await AsyncExecuter.CountAsync(query);

      return new PagedResultDto<AuthorDto>(totalCount, ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
    {
      var author = await _authorRepository.GetAsync(id);

      if (author.Name != input.Name) await _authorManager.ChangeNameAsync(author, input.Name);

      author.BirthDate = input.BirthDate;
      author.ShortBio = input.ShortBio;

      await _authorRepository.UpdateAsync(author);


    }
  }



}