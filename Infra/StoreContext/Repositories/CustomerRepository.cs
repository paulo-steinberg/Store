using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Data;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;
using Infra.StoreContext.DataContexts;
using Domain.StoreContext.Queries;

namespace Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                "spCheckEmail",
                new { Email = email },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public CustomerOrdersCount GetCustomerOrdersCount(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCount>(
                "spGetCustomerOrdersCount",
                new { Document = document },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context
                .Connection
                .Query<ListCustomerQueryResult>(
                    "SELECT [Id], CONCAT([FirstName], ' ', [LastName], [Document], [Email] FROM [Customer]",
                    new { });
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach(var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type,
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
