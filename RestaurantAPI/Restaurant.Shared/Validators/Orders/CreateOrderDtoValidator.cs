using FluentValidation;
using Restaurant.Shared.DTOs.Orders;
using Restaurant.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Shared.Validators.Orders
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.Customer)
                .NotNull().WithMessage(ValidatorsResource.CustomerRequired);

            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage(ValidatorsResource.InvalidOrderItemAmount)
                .Must(items => items.All(item => item.MenuItemId != Guid.Empty && item.Quantity > 0))
                .WithMessage(ValidatorsResource.InvalidOrderItemOrQuantity);
        }
    }
}
