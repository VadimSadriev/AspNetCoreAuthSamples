using System.Collections.Generic;

namespace Auth.Common.Dtos.Exception
{
    /// <summary> Dto for any kind of <see cref="System.Exception"/> </summary>
    public class ExceptionDto
    {
        /// <summary> Exception errors </summary>
        public ICollection<ExceptionErrorDto> Errors { get; set; }
    }
}