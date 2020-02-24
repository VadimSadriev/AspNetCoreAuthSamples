using Auth.Contracts.AccountContracts;
using FluentValidation;

namespace Auth.Web.Infrastructure.ContractValidators.AccountValidators
{
    /// <summary>/ Validation rules for <see cref="RefreshJwtTokenContract"/> </summary>
    public class RefreshJwtTokenContractValidator : AbstractValidator<RefreshJwtTokenContract>
    {
        /// <summary>/ Validation rules for <see cref="RefreshJwtTokenContract"/> </summary>
        public RefreshJwtTokenContractValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty()
                .WithMessage("Token to  refresh cannot be empty")
                .NotNull()
                .WithMessage("Please provide token to refresh");

            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("Refresh token cannot be empty")
                .NotNull()
                .WithMessage(x => $"Please provide refresh token in order to refresh token: {x.Token}");
        }
    }
}
