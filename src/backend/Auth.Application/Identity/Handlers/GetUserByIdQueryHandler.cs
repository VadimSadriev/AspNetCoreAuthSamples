using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Queries;
using Auth.Contracts.AccountContracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Identity.Handlers
{
    /// <summary> Handles <see cref="GetUserByIdQuery"/>x </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseContract>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserResponseContract> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetById(request.UserId);

            return _mapper.Map<UserResponseContract>(user);
        }
    }
}
