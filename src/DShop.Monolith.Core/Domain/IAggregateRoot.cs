using System.Collections.Generic;

namespace DShop.Monolith.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IEvent> Events { get; }
    }
}