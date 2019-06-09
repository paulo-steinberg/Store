using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.StoreContext.Queries
{
    public class CustomerOrdersCount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int Orders { get; set; }
    }
}
