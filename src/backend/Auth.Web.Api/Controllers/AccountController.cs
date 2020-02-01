using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Identity;
using Auth.Web.Infrastructure.Contracts.AccountContracts;
using Auth.Web.Infrastructure.Contracts.ExceptionContracts;
using Auth.Web.Infrastructure.ContractValidators.AccountValidators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Web.Api.Controllers
{
    /// <summary> Main api for account management </summary>
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary> service for user management </summary>
        private readonly IUserManager _userManager;

        /// <summary> mapper </summary>
        private readonly IMapper _mapper;

        /// <summary> Main api for account management </summary>
        public AccountController(
            IUserManager userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>Creates new user </summary>
        [HttpPost("signup")]
        [ProducesResponseType(typeof(UserResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> Signup([FromBody]UserCreateContract userContract)
        {
            var userDto = _mapper.Map<UserCreateDto>(userContract);

            var newUserDto = await _userManager.CreateUser(userDto);

            var result = _mapper.Map<UserResponseContract>(newUserDto);

            return Ok(result);
        }

        /// <summary> Returns jwt auth token for existing user </summary>
        [HttpPost("jwt/signin")]
        [ProducesResponseType(typeof(UserJwtResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> Signup([FromBody]UserSigninContract userSigninContract)
        {
            var userSigninDto = _mapper.Map<UserSigninDto>(userSigninContract);

            var userResponseDto = await _userManager.SigninWithJwt(userSigninDto);

            var responseContract = _mapper.Map<UserJwtResponseContract>(userResponseDto);

            return Ok(responseContract);
        }

        /// <summary> Refreshes jwt token with refresh token and returns new combination </summary>
        [HttpPost("jwt/refresh")]
        [ProducesResponseType(typeof(UserJwtResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> RefreshJwtToken([FromBody]RefreshJwtTokenContract refreshTokenContract)
        {
            var refreshTokenDto = _mapper.Map<RefreshJwtTokenDto>(refreshTokenContract);

            var jwtTokenDto = await _userManager.RefreshJwtToken(refreshTokenDto);

            var responseContract = _mapper.Map<UserJwtResponseContract>(jwtTokenDto);

            return Ok(responseContract);
        }
    }
}
