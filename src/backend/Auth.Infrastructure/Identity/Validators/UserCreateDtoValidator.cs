using Auth.Application.Dtos.Identity;
using Auth.Infrastructure.Identity.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Identity.Validators
{
    /// <summary> Validator for <see cref="UserCreateDto"/> </summary>
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        /// <summary> Validator for <see cref="UserCreateDto"/> </summary>
        public UserCreateDtoValidator(AppDataContext context)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName cannot be empty")
                .NotNull()
                .WithMessage("Please provide UserName in order to signup")
                .MustAsync(async (prop, val, cancToken) =>
                   !await context.Users.AnyAsync(x => x.UserName == val))
                .WithMessage(x => $"User with UserName: {x.UserName} already exists");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Please provide email in order to signup")
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .EmailAddress()
                .WithMessage("Incorrect email address")
                .MustAsync(async (prop, val, cancToken) =>
                 !await context.Users.AnyAsync(x => x.Email == val))
                .WithMessage(x => $"User with email: {x.Email} already exists");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .NotNull()
                .WithMessage("Please provide password in order to signup");
        }
    }
}
