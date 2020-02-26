using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Commands
{
    /// <summary> Command used to signin with jwt </summary>
    public class SigninWithJwtCommand : IRequest<UserJwtResponseContract>
    {
        /// <summary> Command used to signin with jwt </summary>
        public SigninWithJwtCommand(UserSigninContract userSigninContract)
        {
            UserSigninContract = userSigninContract;
        }

        /// <summary> Contract to signin </summary>
        public UserSigninContract UserSigninContract { get; set; }
    }
}
