using Volo.Abp;

namespace BookStore.Domain.Authors
{
    xbu

    public class AuthorAlreadyExistsException  : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}