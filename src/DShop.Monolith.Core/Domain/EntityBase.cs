using System;

namespace DShop.Monolith.Core.Domain
{
    public abstract class EntityBase : IIdentifiable
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        protected EntityBase()
        {
        }

        protected EntityBase(Guid id)
        {
            Id = id;
        }
    }
}