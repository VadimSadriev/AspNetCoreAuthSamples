using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Commands;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Auth.Application.Identity.Validators
{
    /// <summary> Validates incoming <see cref="CreateUserCommand"/> </summary>
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        /// <summary> Validates incoming <see cref="CreateUserCommand"/> </summary>
        public CreateUserCommandValidator(IUserDataContext context)
        {
            RuleFor(x => x.UserCreateContract.UserName)
                .MustAsync(async (prop, val, token) => !await context.Users.AnyAsync(x => x.UserName == val))
                .WithMessage(x => $"User with Username: {x.UserCreateContract.UserName} already exists");

            RuleFor(x => x.UserCreateContract.Email)
                .EmailAddress()
                .WithMessage(x => $"Email: {x.UserCreateContract.Email} is not in correct format")
                .MustAsync(async (prop, val, token) =>
                {
                    return !await context.Users.AnyAsync(x => x.Email == val);
                })
                .WithMessage(x => $"User with Email: {x.UserCreateContract.Email} already exists");
        }
    }
}