using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Auth.Application.Identity.Handlers
{
    /// <summary> Check if reqest contains valid jwt  </summary>
    public class IsTokenValidHandler : IRequestHandler<IsTokenValidCommand, bool>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserManager _userManager;

        /// <summary> Check if reqest contains valid jwt  </summary>
        public IsTokenValidHandler(IHttpContextAccessor httpContextAccessor, IUserManager userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<bool> Handle(IsTokenValidCommand request, CancellationToken cancellationToken)
        {
            if (!AuthenticationHeaderValue.TryParse(_httpContextAccessor.HttpContext.Request.Headers["Authorization"], out var headerValue))
                return false;

            var token = headerValue.Parameter;

            return await _userManager.IsJwtValid(token);
        }
    }
}