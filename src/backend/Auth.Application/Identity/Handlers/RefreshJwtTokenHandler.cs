using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Dtos.Identity;
using Auth.Application.Identity.Commands;
using Auth.Contracts.AccountContracts;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Identity.Handlers
{
    /// <summary> Handles <see cref="RefreshJwtTokenCommand"/> </summary>
    public class RefreshJwtTokenHandler : IRequestHandler<RefreshJwtTokenCommand, UserJwtResponseContract>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public RefreshJwtTokenHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserJwtResponseContract> Handle(RefreshJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshTokenDto = _mapper.Map<RefreshJwtTokenDto>(request.RefreshJwtTokenContract);

            var jwtTokenDto = await _userManager.RefreshJwtToken(refreshTokenDto);

            return _mapper.Map<UserJwtResponseContract>(jwtTokenDto);
        }
    }
}