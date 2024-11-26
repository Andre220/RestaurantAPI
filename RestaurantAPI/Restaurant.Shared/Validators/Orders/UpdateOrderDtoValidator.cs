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
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidatorsResource.IdRequired);

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage(ValidatorsResource.OrderStatusRequired);
        }
    }
}
