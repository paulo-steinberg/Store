using System;
using System.Collections.Generic;
using System.Text;
using Domain.StoreContext.Enums;
using Shared.Entities;

namespace Domain.StoreContext.Entities
{
    public class Delivery : Entity
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

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}
