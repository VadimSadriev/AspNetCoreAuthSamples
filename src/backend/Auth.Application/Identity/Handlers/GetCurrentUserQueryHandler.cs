using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Queries;
using Auth.Contracts.AccountContracts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Identity.Handlers
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserResponseContract>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public GetCurrentUserQueryHandler(
            IHttpContextAccessor  httpContextAccessor,
            IUserManager userManager,
            IMapper mapper)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            _userManager = userManager;
            _mapper = mapper;
        }

        public string UserId { get; set; }

        public async Task<UserResponseContract> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetById(UserId);

            return _mapper.Map<UserResponseContract>(user);
        }
    }
}
