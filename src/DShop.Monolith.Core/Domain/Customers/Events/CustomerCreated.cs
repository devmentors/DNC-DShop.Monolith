using System;

namespace DShop.Monolith.Core.Domain.Customers.Events
{
    public class CustomerCreated : IEvent
    {
        public Guid Id { get;  }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Country { get; }

        public CustomerCreated(Guid id, string firstName, string lastName, 
            string address, string country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Country = country;
        }
    }
}