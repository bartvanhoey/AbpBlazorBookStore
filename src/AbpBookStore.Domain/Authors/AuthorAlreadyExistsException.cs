using Volo.Abp;

namespace AbpBookStore.Domain.Authors
{

    public class AuthorAlreadyExistsException  : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(AbpBookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}