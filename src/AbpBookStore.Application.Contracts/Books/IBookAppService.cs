using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpBookStore.Application.Contracts.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto> 
    {
            Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}