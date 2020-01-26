using System;

namespace Auth.Domain
{
    /// <summary>
    /// Represents refresh token for certain jwt token
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Actual refresh token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Jwt token id
        /// </summary>
        public string JwtId { get; set; }

        /// <summary>
        /// Token creation date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Token expiration date
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Flag if token is already used
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// Flag if token is invalidated
        /// </summary>
        public bool Invalidated { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string AppUserId { get; set; }

        /// <summary>
        /// User token belongs to
        /// </summary>
        public AppUser AppUser { get; set; }
    }
}
