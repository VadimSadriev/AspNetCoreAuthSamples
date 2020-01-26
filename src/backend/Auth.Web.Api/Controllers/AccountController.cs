using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Exception;
using Auth.Common.Dtos.Identity;
using AutoMapper;
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
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionDto))]
        public async Task<IActionResult> Signup([FromBody]UserCreateDto userDto)
        {
            var newUser = await _userManager.CreateUser(userDto);

            var result = _mapper.Map<UserResponseDto>(newUser);

            return Ok(result);
        }

        /// <summary> Returns jwt auth token for existing user </summary>
        [HttpPost("jwt/signin")]
        [ProducesResponseType(typeof(UserJwtResponseDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionDto))]
        public async Task<IActionResult> Signup([FromBody]UserSigninDto userSigninDto)
        {
            var userResponseDto = await _userManager.SigninWithJwt(userSigninDto);

            return Ok(userResponseDto);
        }

        [HttpPost("jwt/refresh")]
        public async Task<IActionResult> RefreshJwtToken([FromBody]RefreshJwtTokenDto refreshTokenDto)
        {
            var jwtTokenDto = await _userManager.RefreshJwtToken(refreshTokenDto);

            return Ok(jwtTokenDto);
        }
    }
}
