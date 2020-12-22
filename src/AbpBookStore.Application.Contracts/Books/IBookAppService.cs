using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpBookStore.Application.Contracts.Books
{
    public interface IBookAppService : ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateBookDto, UpdateBookDto> 
    {
            
    }
}