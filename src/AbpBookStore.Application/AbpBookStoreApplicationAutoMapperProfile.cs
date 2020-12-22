using AbpBookStore.Application.Contracts.Books;
using AbpBookStore.Domain.Books;
using AutoMapper;

namespace AbpBookStore
{
  public class AbpBookStoreApplicationAutoMapperProfile : Profile
  {
    public AbpBookStoreApplicationAutoMapperProfile()
    {
      /* You can configure your AutoMapper mapping configuration here.
       * Alternatively, you can split your mapping configurations
       * into multiple profile classes for a better organization. */

      CreateMap<Book, BookDto>();
      CreateMap<CreateBookDto, Book>();
      CreateMap<UpdateBookDto, Book>();
    }
  }
}
