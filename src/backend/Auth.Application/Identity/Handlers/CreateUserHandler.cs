using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Commands;
using Auth.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Application.Identity.Handlers
{
    /// <summary> Handles <see cref="CreateUserCommand"/> to create new user </summary>
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, AppUser>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        /// <summary> Handles <see cref="CreateUserCommand"/> to create new user </summary>
        public CreateUserHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary> Handles request </summary>
        public async Task<AppUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = await _userManager.CreateUser(request.UserCreateDto);

            return newUser;
        }
    }
}
