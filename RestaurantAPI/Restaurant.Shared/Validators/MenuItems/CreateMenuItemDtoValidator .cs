using FluentValidation;
using Restaurant.Shared.DTOs.MenuItems;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.MenuItems
{
    public class CreateMenuItemDtoValidator : AbstractValidator<CreateMenuItemDTO>
    {
        public CreateMenuItemDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidatorsResource.NameFieldRequired);

            RuleFor(x => x.PriceCents)
                .GreaterThan(0).WithMessage(ValidatorsResource.InvalidPriceValue);
        }
    }
}
