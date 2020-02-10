using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.Web.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var validationFailures = new List<ValidationFailure>();
                
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                foreach (var error in errors)
                {
                    foreach (var errorMessage in error.Value)
                    {
                        validationFailures.Add(new ValidationFailure(error.Key, errorMessage));
                    }
                }
                
                throw new ValidationException(validationFailures);
            }

            await next();
        }
    }
}