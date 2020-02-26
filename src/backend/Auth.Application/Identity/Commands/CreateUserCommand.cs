using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Commands
{
    /// <summary> Command used to create user </summary>
    public class CreateUserCommand : IRequest<string>
    {
        /// <summary> Command used to create user </summary>
        public CreateUserCommand(UserCreateContract userCreateContract)
        {
            UserCreateContract = userCreateContract;
        }

        /// <summary> Contract to create user </summary>
        public UserCreateContract UserCreateContract { get; set; }
    }
}
