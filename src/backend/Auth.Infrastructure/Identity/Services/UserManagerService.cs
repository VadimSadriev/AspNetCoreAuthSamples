using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Dtos.Identity;
using Auth.Application.Exceptions;
using Auth.Common.Extensions;
using Auth.Domain;
using Auth.Infrastructure.Auth.Jwt;
using Auth.Infrastructure.Identity.Data;
using Auth.Infrastructure.Identity.Exceptions;
using Auth.Infrastructure.Identity.Extensions;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Identity.Services
{
    /// <summary>Provides functionality for user management </summary>
    public class UserManagerService : IUserManager
    {
        public readonly UserManager<AppUser> _userManager;
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IMapper _mapper;
        private readonly AppDataContext _context;


        /// <summary> Provides functionality for user management </summary>
        public UserManagerService(
            UserManager<AppUser> userManager,
            IJwtAuthService jwtAuthService,
            IMapper mapper,
            AppDataContext context
            )
        {
            _context = context;
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

            var jwtTokenDto = await _jwtAuthService.GetToken(user);

            userResponseDto.Token = jwtTokenDto.Token;
            userResponseDto.RefreshToken = jwtTokenDto.RefreshToken;

            return userResponseDto;
        }

        /// <summary> Returns user by id </summary>
        public async Task<AppUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id) ??
                throw new EntityNotFoundException($"User with identifier {id} not found");
        }

        /// <summary> Refreshes jwt token</summary>
        public async Task<UserJwtResponseDto> RefreshJwtToken(RefreshJwtTokenDto refreshJwtTokenDto)
        {
            var validatedToken = _jwtAuthService.GetPrincipleFromToken(refreshJwtTokenDto.Token);

            if (validatedToken == null)
                throw new AuthenticationException("Invalid token");

            var tokenExpireDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var tokenExpireDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(tokenExpireDateUnix);

            if (tokenExpireDateUtc > DateTime.UtcNow)
                throw new AuthenticationException("Token has not expired yet");

            // get token id
            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == refreshJwtTokenDto.RefreshToken);

            if (storedRefreshToken == null)
                throw new AuthenticationException("Passed refresh token does not exist");

            if (DateTime.UtcNow > storedRefreshToken.ExpireDate)
                throw new AuthenticationException("Passed refresh token has expired");

            if (storedRefreshToken.Invalidated)
                throw new AuthenticationException("Passed refresh token is invalidated");

            if (storedRefreshToken.IsUsed)
                throw new AuthenticationException("Passed refresh token has been used");

            if (storedRefreshToken.JwtId != jti)
                throw new AuthenticationException("Passed refresh token does not match given JWT");

            try
            {
                storedRefreshToken.IsUsed = true;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new AppException("An error occurred during refreshing token", ex);
            }

            var userId = validatedToken.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var user = await GetById(userId);

            var userResponseDto = _mapper.Map<UserJwtResponseDto>(user);

            var jwtTokenDto = await _jwtAuthService.GetToken(user);

            userResponseDto.Token = jwtTokenDto.Token;
            userResponseDto.RefreshToken = jwtTokenDto.RefreshToken;

            return userResponseDto;
        }
    }
}
