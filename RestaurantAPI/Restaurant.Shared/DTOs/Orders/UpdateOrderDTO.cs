using Restaurant.Domain.Identity;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Shared.DTOs.Orders
{
    public record UpdateOrderDto(Guid Id, 
        User UpdatedBy,
        OrderStatus Status);
}
