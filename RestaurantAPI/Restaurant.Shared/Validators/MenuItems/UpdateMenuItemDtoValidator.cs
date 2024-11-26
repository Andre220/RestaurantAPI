using FluentValidation;
using Restaurant.Shared.DTOs.MenuItems;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.MenuItems
{
    public class UpdateMenuItemDtoValidator : AbstractValidator<UpdateMenuItemDTO>
    {
        public UpdateMenuItemDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidatorsResource.IdRequired);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidatorsResource.NameFieldRequired);

            RuleFor(x => x.PriceCents)
                .GreaterThan(0).WithMessage(ValidatorsResource.InvalidPriceValue);
        }
    }
}
