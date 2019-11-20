using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Identity
{
    /// <summary> Application user authenticated in application </summary>
    public class AppUser : IdentityUser<string> { }
}
