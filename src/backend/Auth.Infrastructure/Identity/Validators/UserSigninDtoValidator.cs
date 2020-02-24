using Auth.Application.Dtos.Identity;
using FluentValidation;

namespace Auth.Infrastructure.Identity.Validators
{
    public class UserSigninDtoValidator : AbstractValidator<UserSigninDto>
    {
        public UserSigninDtoValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotNull()
                .WithMessage("Please provider UserName or Email in order to signin")
                .NotEmpty()
                .WithMessage("UserName or Email cannot be empty");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Please provide password in order to signin")
                .NotEmpty()
                .WithMessage("Password cannot be empty");
        }
    }
}
