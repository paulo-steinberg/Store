using System.Collections.Generic;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;

namespace Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCount GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
    }
}