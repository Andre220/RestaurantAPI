﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
