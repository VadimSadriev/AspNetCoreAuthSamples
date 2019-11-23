using Auth.Application.Common.Interfaces.Identity;
using Auth.Common.Dtos.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Web.Api.Controllers
{
    /// <summary> Main api for account management </summary>
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

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserCreateDto userDto)
        {
            var newUser = await _userManager.CreateUser(userDto);

            var result = _mapper.Map<UserDto>(newUser);

            return Ok(result);
        }
    }
}
