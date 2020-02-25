using Auth.Application.Common.Interfaces.Identity;
using Auth.Application.Identity.Commands;
using FluentValidation;

namespace Auth.Application.Identity.Validators
{
    /// <summary> Validates incoming <see cref="CreateUserCommand"/> </summary>
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        /// <summary> Validates incoming <see cref="CreateUserCommand"/> </summary>
        public CreateUserCommandValidator(IUserDataContext context)
        {

        }
    }
}
