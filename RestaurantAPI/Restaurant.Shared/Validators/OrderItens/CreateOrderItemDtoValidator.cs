using FluentValidation;
using Restaurant.Shared.DTOs.Orders;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.OrderItens
{
    public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDTO>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(x => x.MenuItemId)
                .NotEmpty().WithMessage(ValidatorsResource.IdRequired);

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage(ValidatorsResource.InvalidQuantityValue);
        }
    }
}
