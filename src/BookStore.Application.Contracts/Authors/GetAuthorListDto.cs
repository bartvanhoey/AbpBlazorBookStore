using Volo.Abp.Application.Dtos;

namespace BookStore.Application.Contracts.Authors
{
  public class GetAuthorListDto :  PagedAndSortedResultRequestDto 
  {
    public string Filter { get; set; }
  }
}