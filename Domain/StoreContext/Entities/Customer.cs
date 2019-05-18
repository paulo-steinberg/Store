using System;

namespace Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, string email, string document, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = Address;
        }

        public string FirstName { get;  private set; }

        public string LastName { get; private set; }

        public string Document { get; private set; }

        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
    
}
