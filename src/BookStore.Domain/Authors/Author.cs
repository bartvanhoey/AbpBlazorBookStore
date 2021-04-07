using System;
using BookStore.Domain.Shared.Authors;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Domain.Authors
{
  public class Author : FullAuditedAggregateRoot<Guid>
  {
    public string Name { get; private set; }
    public DateTime BirthDate { get; set; }
    public string ShortBio { get; set; }

    private Author() { }

    internal Author(Guid id, [NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null)
    {
      SetName(name);
      BirthDate = birthDate;
      ShortBio = shortBio;
    }

    internal Author ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
    }
  }
}