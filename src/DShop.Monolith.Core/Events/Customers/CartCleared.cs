using System;

namespace DShop.Monolith.Core.Events.Customers
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