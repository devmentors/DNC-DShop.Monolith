using System;

namespace DShop.Monolith.Core.Domain.Products.Events
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
