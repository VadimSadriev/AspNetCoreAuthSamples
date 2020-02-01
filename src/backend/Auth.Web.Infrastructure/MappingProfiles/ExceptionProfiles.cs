using Auth.Web.Infrastructure.Contracts.ExceptionContracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Web.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Mapping for all kind of exceptions <see cref="Exception"/>
    /// </summary>
    public class ExceptionProfiles : Profile
    {
        /// <summary>
        /// Mapping for all kind of exceptions <see cref="Exception"/>
        /// </summary>
        public ExceptionProfiles()
        {
            CreateMap<Exception, ExceptionContract>()
                .ForMember(x => x.Errors, o => o.MapFrom(x => MapError(x)));
        }

        private IEnumerable<ExceptionErrorContract> MapError(Exception ex)
        {
            var srcExc = ex;

            while (srcExc != null)
            {
                yield return new ExceptionErrorContract { Type = srcExc.GetType().Name, Message = srcExc.Message };
                srcExc = srcExc.InnerException;
            }
        }
    }
}
