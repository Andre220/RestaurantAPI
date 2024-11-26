using FluentValidation;
using Restaurant.Shared.DTOs.Customers;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.Customers
{

    public class UpdateCustomerDTOValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidatorsResource.IdRequired);

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
