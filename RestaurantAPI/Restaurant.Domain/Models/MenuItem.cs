using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal PriceCents { get; set; }//Todo: verify if this type is correct for this kind of information

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
