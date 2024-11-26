using FluentValidation;
using Restaurant.Shared.DTOs;
using Restaurant.Shared.DTOs.Auth;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.Auth
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidatorsResource.EmailRequired)
                .EmailAddress().WithMessage(ValidatorsResource.InvalidEmail);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidatorsResource.PasswordRequired)
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage(ValidatorsResource.InvalidPasswordContent)
                .MinimumLength(8).WithMessage(string.Format(ValidatorsResource.InvalidPasswordLength, 8));

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ValidatorsResource.FirstNameRequired);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ValidatorsResource.LastNameRequired);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(ValidatorsResource.PhoneNumberRequired)
                .Matches(@"^\d{10,11}$").WithMessage(ValidatorsResource.InvalidPhoneNumberFormat);
        }
    }
}
