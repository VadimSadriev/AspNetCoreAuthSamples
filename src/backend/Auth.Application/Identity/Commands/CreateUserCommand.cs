using Auth.Application.Dtos.Identity;
using Auth.Domain;
using MediatR;

namespace Auth.Application.Identity.Commands
{
    /// <summary> Command used to create new user </summary>
    public class CreateUserCommand : IRequest<AppUser>
    {
        /// <summary> Command used to create new user </summary>
        public CreateUserCommand(UserCreateDto userCreateDto)
        {
            UserCreateDto = userCreateDto;
        }

        public UserCreateDto UserCreateDto { get; set; }
    }
}
