using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace BookStore.Domain.Authors
{
    public class AuthorManager :  DomainService
    {
        private readonly IAuthorRepository _authorRepository;
      
        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync([NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            if (existingAuthor != null)  { throw new AuthorAlreadyExistsException(name);}
            
            return new Author(GuidGenerator.Create(), name, birthDate, shortBio);
        }


        


    }
}