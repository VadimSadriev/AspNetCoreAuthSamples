using Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Common.Interfaces.Identity
{
    /// <summary> Data context for users </summary>
    public interface IUserDataContext
    {
        /// <summary> Application users </summary>
        DbSet<AppUser> Users { get; set; }
    }
}
