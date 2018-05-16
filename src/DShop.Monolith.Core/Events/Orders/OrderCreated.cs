using System;

namespace DShop.Monolith.Core.Events.Orders
{
    public class OrderCreated : IEvent
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public long Number { get; }

        public OrderCreated(Guid id, Guid customerId, long number)
        {
            Id = id;
            CustomerId = customerId;
            Number = number;
        }
    }
}
