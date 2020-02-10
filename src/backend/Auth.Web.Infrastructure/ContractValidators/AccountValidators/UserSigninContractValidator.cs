using Auth.Web.Infrastructure.Contracts.AccountContracts;
using FluentValidation;

namespace Auth.Web.Infrastructure.ContractValidators.AccountValidators
{
    /// <summary> Validation rules for <see cref="UserSigninContract"/> </summary>
    public class UserSigninContractValidator : AbstractValidator<UserSigninContract>
    {
        /// <summary> Validation rules for <see cref="UserSigninContract"/> </summary>
        public UserSigninContractValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotEmpty()
                .WithMessage("Username or email cannot be empty")
                .NotNull()
                .WithMessage("Please provide username or email in order to signin");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .NotNull()
                .WithMessage("Please provide password in order to signin");
        }
    }
}
