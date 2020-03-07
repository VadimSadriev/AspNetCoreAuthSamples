using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Queries
{
    /// <summary>
    /// Query to return current authenticated user
    /// </summary>
    public class GetCurrentUserQuery : IRequest<UserResponseContract>
    {
        
    }
}
