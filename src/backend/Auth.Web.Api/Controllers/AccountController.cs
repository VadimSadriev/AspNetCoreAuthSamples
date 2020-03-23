using Auth.Application.Identity.Commands;
using Auth.Contracts.AccountContracts;
using Auth.Web.Contracts.ExceptionContracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Auth.Web.Api.Controllers
{
    /// <summary> Main api for account management </summary>
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary> Main api for account management </summary>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Creates new user </summary>
        [HttpPost("signup")]
        [ProducesResponseType(typeof(UserResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> Signup([FromBody]UserCreateContract userContract)
        {
            var command = new CreateUserCommand(userContract);

            await _mediator.Send(command);

            return Ok();
        }

        /// <summary> Returns jwt auth token for existing user </summary>
        [HttpPost("jwt/signin")]
        [ProducesResponseType(typeof(UserJwtResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> Signin([FromBody]UserSigninContract userSigninContract)
        {
            var command = new SigninWithJwtCommand(userSigninContract);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary> Refreshes jwt token with refresh token and returns new combination </summary>
        [HttpPost("jwt/refresh")]
        [ProducesResponseType(typeof(UserJwtResponseContract), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> RefreshJwtToken([FromBody]RefreshJwtTokenContract refreshTokenContract)
        {
            var command = new RefreshJwtTokenCommand(refreshTokenContract);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary> Check if user with passed token is authenticated </summary>
        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ExceptionContract))]
        public async Task<IActionResult> IsAuthenticated()
        {
            var isTokenValid = await _mediator.Send(new IsTokenValidCommand());

            return Ok(isTokenValid);
        }
    }
}
