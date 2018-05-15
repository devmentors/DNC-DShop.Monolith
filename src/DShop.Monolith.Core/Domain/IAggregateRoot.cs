using System.Collections.Generic;
using DShop.Monolith.Core.Events;

namespace DShop.Monolith.Core.Domain
{
    //Marker interface
    public interface IAggregateRoot
    {
        IEnumerable<IEvent> Events { get; }
    }
}