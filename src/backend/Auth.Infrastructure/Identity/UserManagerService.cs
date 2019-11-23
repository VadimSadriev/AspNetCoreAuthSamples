using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Identity;
using Auth.Domain;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        public Task<AppUser> CreateUser(UserCreateDto userDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
