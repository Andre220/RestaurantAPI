using FluentValidation;
using Restaurant.Shared.DTOs.Orders;
using Restaurant.Shared.Resources;

namespace Restaurant.Shared.Validators.Orders
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidatorsResource.IdRequired);

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage(ValidatorsResource.CreatedAtRequired);

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage(ValidatorsResource.OrderStatusRequired);

            //RuleFor(x => x.TotalPriceCents)
            //    .GreaterThan(0).WithMessage("Total price must be greater than 0.");

            RuleFor(x => x.Customer)
                .NotNull().WithMessage(ValidatorsResource.CustomerRequired);

            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage(ValidatorsResource.InvalidOrderItemAmount);
        }
    }
}
