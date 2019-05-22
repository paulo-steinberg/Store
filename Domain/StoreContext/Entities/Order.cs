using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.StoreContext.Enums;

namespace Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreatedAtDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();

        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreatedAtDate { get; private set; }
        public  EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void PlaceAnOrder()
        {

        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
            Delivery delivery = new Delivery(DateTime.Now.AddDays(5));
            delivery.Ship();
            _deliveries.Add(delivery);
        }

        public void AddItem(OrderItem item)
        {
            //Valida Item
            //Adiciona ao pedido
            _items.Add(item);
        }
    }
}
