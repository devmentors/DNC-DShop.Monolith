using System;

namespace DShop.Monolith.Core.Domain.Customers.Events
{
    public class CartCleared : IEvent
    {
        public Guid CustomerId { get;  }

        public CartCleared(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}