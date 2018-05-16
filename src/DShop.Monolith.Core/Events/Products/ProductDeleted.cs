using System;

namespace DShop.Monolith.Core.Events.Products
{
    public class ProductDeleted : IEvent
    {
        public Guid Id { get; }

        public ProductDeleted(Guid id)
        {
            Id = id;
        }
    }
}
