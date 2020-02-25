using Auth.Contracts.AccountContracts;
using MediatR;

namespace Auth.Application.Identity.Queries
{
    /// <summary> Query to return user by id </summary>
    public class GetUserByIdQuery : IRequest<UserResponseContract>
    {
        /// <summary> Query to return user by id </summary>
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
