using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;

namespace Tests.Mocks
{
    public class CustomerRepositoryMock : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public CustomerOrdersCount GetCustomerOrdersCount(string document)
        {
            return new CustomerOrdersCount() { };
        }

        public void Save(Customer customer)
        {

        }
    }
}
