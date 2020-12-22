using System;
using AbpBookStore.Domain.Shared.Books;
using Volo.Abp.Application.Dtos;

namespace AbpBookStore.Application.Contracts.Books
{
    public class BookDto :  FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
    }
}