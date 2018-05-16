using System;

namespace DShop.Monolith.Core.Events.Customers
{
    public class ProductDeletedFromCart : IEvent
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        public ProductDeletedFromCart(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }        
    }
}