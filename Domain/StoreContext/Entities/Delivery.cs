using System;
using System.Collections.Generic;
using System.Text;
using Domain.StoreContext.Enums;

namespace Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimateDeliveryDate)
        {
            CreatedAt = DateTime.Now;
            DeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }
    }
}
