using System;

namespace DShop.Monolith.Core.Domain
{
    public abstract class Entity : IIdentifiable
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}