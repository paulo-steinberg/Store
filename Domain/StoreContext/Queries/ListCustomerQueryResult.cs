using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string document { get; set; }
        public string email { get; set; }

    }
}
