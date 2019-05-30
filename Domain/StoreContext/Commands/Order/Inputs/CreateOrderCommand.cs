using System;
using System.Collections.Generic;
using Domain.StoreContext.ValueObjects;
using FluentValidator;
using FluentValidator.Validation;
using Shared.Commands;

namespace Domain.StoreContext.Commands.Order.Inputs
{
    public class CreateOrderCommand : Notifiable, ICommand
    {

        public CreateOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Cusomer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Cusomer.ToString(), 8, "Customer", "Identificador do cliente inválido.")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado.")
            );
            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}