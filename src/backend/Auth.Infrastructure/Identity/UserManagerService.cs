using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Identity;
using Auth.Common.Exceptions;
using Auth.Domain;
using Auth.Infrastructure.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Identity
{
    /// <summary>Provides functionality for user management </summary>
    public class UserManagerService : IUserManager
    {
        /// <summary> service for managing user </summary>
        public readonly UserManager<AppUser> _userManager;

        /// <summary>Provides functionality for user management </summary>
        public UserManagerService(
            UserManager<AppUser> userManager
            )
        {
            _userManager = userManager;
        }

        /// <summary> Creates new user  </summary>
        public async Task<AppUser> CreateUser(UserCreateDto userDto)
        {
            var user = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
                return await GetById(user.Id);

            throw new AppException(result.Errors.AggregateErrors());
        }

        /// <summary> Returns user by id </summary>
        public async Task<AppUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id) ??
                throw new EntityNotFoundException($"User with identifier {id} not found");
        }
    }
}
