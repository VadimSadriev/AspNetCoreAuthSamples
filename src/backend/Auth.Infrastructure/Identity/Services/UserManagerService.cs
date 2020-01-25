using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Identity;
using Auth.Common.Exceptions;
using Auth.Common.Extensions;
using Auth.Domain;
using Auth.Infrastructure.Auth.Jwt;
using Auth.Infrastructure.Identity.Exceptions;
using Auth.Infrastructure.Identity.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Identity.Services
{
    /// <summary>Provides functionality for user management </summary>
    public class UserManagerService : IUserManager
    {
        /// <summary> service for managing user </summary>
        public readonly UserManager<AppUser> _userManager;

        /// <summary> provides token generation for user </summary>
        private readonly IJwtAuthService _jwtAuthService;

        /// <summary> Mapper </summary>
        private readonly IMapper _mapper;

        /// <summary>Provides functionality for user management </summary>
        public UserManagerService(
            UserManager<AppUser> userManager,
            IJwtAuthService jwtAuthService,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtAuthService = jwtAuthService;
        }

        /// <summary> Creates new user  </summary>
        public async Task<AppUser> CreateUser(UserCreateDto userDto)
        {
            var user = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
                return await GetById(user.Id);

            throw new AppException(result.Errors.AggregateErrors());
        }

        /// <summary> Checks user existens and return jwt auth token </summary>
        public async Task<UserJwtResponseDto> SigninWithJwt(UserSigninDto userSigninDto)
        {
            var isEmail = userSigninDto.UserNameOrEmail.IsEmail();

            var user = isEmail
                 ? await _userManager.FindByEmailAsync(userSigninDto.UserNameOrEmail)
                 : await _userManager.FindByNameAsync(userSigninDto.UserNameOrEmail);

            if (user == null)
                throw new SigninException();

            var userResponseDto = _mapper.Map<UserJwtResponseDto>(user);

            userResponseDto.Token = _jwtAuthService.GetToken(user);

            return userResponseDto;
        }

        /// <summary> Returns user by id </summary>
        public async Task<AppUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id) ??
                throw new EntityNotFoundException($"User with identifier {id} not found");
        }
    }
}
