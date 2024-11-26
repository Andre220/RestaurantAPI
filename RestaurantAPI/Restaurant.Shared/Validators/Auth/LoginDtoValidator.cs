using FluentValidation;
using Restaurant.Shared.DTOs;
using Restaurant.Shared.DTOs.Auth;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.Auth
{
    public class LoginDtoValidator : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidatorsResource.EmailRequired)
                .EmailAddress().WithMessage(ValidatorsResource.InvalidEmail);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidatorsResource.PasswordRequired);
        }
    }
}
