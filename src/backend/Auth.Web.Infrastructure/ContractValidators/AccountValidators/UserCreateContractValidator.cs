using Auth.Web.Contracts.AccountContracts;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Auth.Web.Infrastructure.ContractValidators.AccountValidators
{
    public class UserCreateContractValidator : AbstractValidator<UserCreateContract>
    {
        public UserCreateContractValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty")
                .NotNull()
                .WithMessage("Please provide UserName in order to signup");
        }
    }
}
