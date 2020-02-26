using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Commands
{
    /// <summary> Command used to refresh jwt token </summary>
    public class RefreshJwtTokenCommand : IRequest<UserJwtResponseContract>
    {
        /// <summary> Command used to refresh jwt token </summary>
        public RefreshJwtTokenCommand(RefreshJwtTokenContract refreshJwtTokenContract)
        {
            RefreshJwtTokenContract = refreshJwtTokenContract;
        }

        public RefreshJwtTokenContract RefreshJwtTokenContract { get; set; }
    }
}
