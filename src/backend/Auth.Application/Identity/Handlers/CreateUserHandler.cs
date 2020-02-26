using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Dtos.Identity;
using Auth.Application.Identity.Commands;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Identity.Handlers
{
    /// <summary>
    /// Handles <see cref="CreateUserCommand"/>
    /// </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public CreateUserHandler(IUserManager userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = _mapper.Map<UserCreateDto>(request.UserCreateContract);

            return await _userManager.CreateUser(userDto);
        }
    }
}
