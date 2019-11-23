using Microsoft.AspNetCore.Identity;

namespace Auth.Domain
{
    /// <summary> Application user authenticated in application </summary>
    public class AppUser : IdentityUser<string> { }
}
