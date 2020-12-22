using Volo.Abp.Application.Dtos;

namespace AbpBookStore.Application.Contracts.Authors
{
  public class GetAuthorListDto :  PagedAndSortedResultRequestDto
  {
    public string Filter { get; set; }
  }
}