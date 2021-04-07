using System;
using System.Threading.Tasks;
using BookStore.Application.Contracts.Authors;
using Shouldly;
using Xunit;

namespace BookStore.Application.Tests.Authors
{
    public class AuthorAppService_Tests :  BookStoreApplicationTestBase
    {
            private readonly IAuthorAppService _authorAppService;

        public AuthorAppService_Tests()
        {
            _authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Authors_Without_Any_Filter()
        {
             var result = await _authorAppService.GetListAsync(new GetAuthorListDto());

             result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
             result.TotalCount.ShouldBeGreaterThan(2);
             result.Items.ShouldContain(i => i.Name == "George Orwell");
             result.Items.ShouldContain(i => i.Name == "Douglas Adam");
        }

    }
}
