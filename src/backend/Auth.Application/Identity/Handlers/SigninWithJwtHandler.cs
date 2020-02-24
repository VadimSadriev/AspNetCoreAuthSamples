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
    /// <summary> Handles <see cref="SigninWithJwtCommand"/> </summary>
    public class SigninWithJwtHandler : IRequestHandler<SigninWithJwtCommand, UserJwtResponseContract>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        /// <summary> Handles <see cref="SigninWithJwtCommand"/> </summary>
        public SigninWithJwtHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserJwtResponseContract> Handle(SigninWithJwtCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserSigninDto>(request.UserSigninContract);

            var result = await _userManager.SigninWithJwt(dto);

            return _mapper.Map<UserJwtResponseContract>(result);
        }
    }
}