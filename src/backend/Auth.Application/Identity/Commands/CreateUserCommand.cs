using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Commands
{
    /// <summary>
    /// Command used to create user
    /// </summary>
    public class CreateUserCommand : IRequest<string>
    {
        public UserCreateContract UserCreateContract { get; set; }

        public CreateUserCommand(UserCreateContract userCreateContract)
        {
            UserCreateContract = userCreateContract;
        }
    }
}
