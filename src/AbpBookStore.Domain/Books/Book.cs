using System;
using AbpBookStore.Domain.Shared.Books;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpBookStore.Domain.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public Guid AuthorId { get; set; }
        
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}