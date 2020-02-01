using Auth.Web.Infrastructure.Contracts.AccountContracts;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Web.Infrastructure.ContractValidators.AccountValidators
{
    public class UserCreateContractValidator : AbstractValidator<UserCreateContract>, IValidatorInterceptor
    {
        public UserCreateContractValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty")
                .NotNull()
                .WithMessage("Please provide UserName in order to signup");
        }

        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            return result;
        }

        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
