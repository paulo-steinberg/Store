using System;
using Shared.Commands;

namespace Domain.StoreContext.Commands.Customer.Outputs
{
    public class CreateCustomerCommandResult : IcommandResult
    {

        public CreateCustomerCommandResult()
        {
            
        }

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}