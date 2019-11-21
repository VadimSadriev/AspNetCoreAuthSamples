using Auth.Application.Common.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Web.Api.Controllers
{
    /// <summary> Main api for account management </summary>
    public class AccountController : Controller
    {
        /// <summary> service for user management </summary>
        private readonly IUserManager _userManager;

        /// <summary> Main api for account management </summary>
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }
    }
}
