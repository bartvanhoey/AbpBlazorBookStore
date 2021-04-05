using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Books;
using BookStore.Application.Contracts.Books.Dtos;
using BookStore.Domain.Shared.Books;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace BookStore.Application.Tests.Books
{
  public class BookAppServiceTests : BookStoreApplicationTestBase
  {
    private readonly IBookAppService _bookAppService;

    public BookAppServiceTests()
    {
      _bookAppService = GetRequiredService<IBookAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
      var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());

      result.TotalCount.ShouldBeGreaterThanOrEqualTo(0);
      result.Items.ShouldContain(i => i.Name == "1984");
    }

    [Fact]
    public async Task Should_Create_A_Valid_Book()
    {
      var result = await _bookAppService.CreateAsync(
          new CreateUpdateBookDto
          {
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
    public async Task Should_Not_Create_A_Book_Without_Name()
    {

      var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
      {
        await _bookAppService.CreateAsync(
          new CreateUpdateBookDto
              {
                Name = "",
                Price = 10,
                PublishDate = DateTime.Now,
                Type = BookType.ScienceFiction

              }
      );
      });

      exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }
  }
}