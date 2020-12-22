using System;
using System.ComponentModel.DataAnnotations;
using AbpBookStore.Domain.Shared.Authors;

namespace AbpBookStore.Application.Contracts.Authors
{
  public class CreateAuthorDto
  {

    [Required]
    [StringLength(AuthorConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public string ShortBio { get; set; }

  }
}