using System;
using System.Collections.Generic;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }


        public GetCustomerQueryResult GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {

        }
    }
}
