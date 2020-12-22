

using System;
using System.Linq;
using System.Threading.Tasks;
using AbpBookStore.Application.Contracts.Authors;
using AbpBookStore.Application.Contracts.Books;
using AbpBookStore.Domain.Shared.Books;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace AbpBookStore.Application.Tests.Books
{
  public class BookAppService_Tests : AbpBookStoreApplicationTestBase
  {
    private readonly IBookAppService _bookAppService;
    private readonly IAuthorAppService _authorAppService;

    public BookAppService_Tests()
    {
      _bookAppService = GetRequiredService<IBookAppService>();
      _authorAppService = GetRequiredService<IAuthorAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
      var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());

      result.TotalCount.ShouldBeGreaterThanOrEqualTo(0);
      result.Items.ShouldContain(b => b.Name == "1984" && b.AuthorName == "George Orwell");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Book()
    {
      var authors = await _authorAppService.GetListAsync(new GetAuthorListDto());
      var firstAuthor = authors.Items.First();

      var result = await _bookAppService.CreateAsync(
        new CreateBookDto
        {
          AuthorId = firstAuthor.Id,
          Name = "New test book 42",
          Price = 10,
          PublishDate = DateTime.Now,
          Type = BookType.ScienceFiction
        }
      );

      result.Id.ShouldNotBe(Guid.Empty);
      result.Name.ShouldBe("New test book 42");
    }

    [Fact]
    public async Task Should_Not_Create_A_Book_Without_A_Name()
    {
      var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
      {
        var result = await _bookAppService.CreateAsync(
        new CreateBookDto
        {
          Name = "",
          Price = 10,
          PublishDate = DateTime.Now,
          Type = BookType.ScienceFiction
        }
      );
      });

      exception.ValidationErrors.ShouldContain(err =>
          err.MemberNames.Any(mem => mem == "Name"));
    }



  }
}