using AbpBookStore.Application.Contracts.Authors;
using AbpBookStore.Application.Contracts.Books;
using AutoMapper;

namespace AbpBookStore.Blazor
{
    public class AbpBookStoreBlazorAutoMapperProfile : Profile
    {
        public AbpBookStoreBlazorAutoMapperProfile()
        {
            CreateMap<BookDto, UpdateBookDto>();
            CreateMap<AuthorDto, UpdateAuthorDto>();            
        }
    }
}
