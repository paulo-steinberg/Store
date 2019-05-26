using System;
using System.Collections.Generic;

namespace Domain.StoreContext.Commands.Order.Inputs
{
    public class CreateOrderCommand
    {
        public Guid Cusomer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}