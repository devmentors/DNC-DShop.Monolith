using System;
using System.Collections.Generic;

namespace DShop.Monolith.Core.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly ISet<IEvent> _events = new HashSet<IEvent>();
        public IEnumerable<IEvent> Events => _events;

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(Guid id) : base(id)
        {
        }

        protected void AddEvent(IEvent @event) => _events.Add(@event);
        protected void ClearEvents() => _events.Clear();
    }
}