using System.Collections.Generic;
using DShop.Monolith.Core.Events;

namespace DShop.Monolith.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IEvent> Events { get; }
    }
}