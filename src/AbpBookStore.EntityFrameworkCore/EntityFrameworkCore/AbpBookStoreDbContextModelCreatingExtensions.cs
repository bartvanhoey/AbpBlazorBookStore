using AbpBookStore.Domain.Authors;
using AbpBookStore.Domain.Books;
using AbpBookStore.Domain.Shared.Authors;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpBookStore.EntityFrameworkCore
{
    public static class AbpBookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpBookStoreConsts.DbTablePrefix + "YourEntities", AbpBookStoreConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Book>(b =>
            {
                b.ToTable(AbpBookStoreConsts.DbTablePrefix + "Books", AbpBookStoreConsts.DbSchema);
                b.ConfigureByConvention();
            
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                // b.HasIndex(x => x.Name);
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(AbpBookStoreConsts.DbTablePrefix + "Authors", AbpBookStoreConsts.DbSchema);
                b.ConfigureByConvention();
            
                b.Property(x => x.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });
        }
    }
}