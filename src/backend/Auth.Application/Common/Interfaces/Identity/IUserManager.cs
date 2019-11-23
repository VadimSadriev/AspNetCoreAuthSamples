using Auth.Common.Dtos.Identity;
using Auth.Domain;
using System.Threading.Tasks;

namespace Auth.Application.Common.Interfaces.Identity
{
    /// <summary>Provides functionality for user management </summary>
    public interface IUserManager
    {
        /// <summary> Creates new user  </summary>
        Task<AppUser> CreateUser(UserCreateDto userDto);
    }
}
