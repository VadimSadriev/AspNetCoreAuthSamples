using Auth.Web.Infrastructure.Contracts.AccountContracts;
using FluentValidation;

namespace Auth.Web.Infrastructure.ContractValidators.AccountValidators
{
    /// <summary> Validation rules for <see cref="UserCreateContract"/> </summary>
    public class UserCreateContractValidator : AbstractValidator<UserCreateContract>
    {
        /// <summary> Validation rules for <see cref="UserCreateContract"/> </summary>
        public UserCreateContractValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty")
                .NotNull()
                .WithMessage("Please provide UserName in order to signup");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .NotNull()
                .WithMessage("Please provide Email in order to signup");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .NotNull()
                .WithMessage("Please provider password in order to signup");
        }
    }
}
