using System;
using System.Threading.Tasks;
using Autofac;
using DShop.Monolith.Core.Domain;

namespace DShop.Monolith.Services.Dispatchers
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _context;

        public EventDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync(params IEvent[] events)
        {
            foreach (var @event in events)
            {
                var eventType = @event.GetType();
                var handlerType = typeof (IEventHandler<>).MakeGenericType(eventType);
                await DispatchAsync(handlerType, @event);
            }
        }

        private async Task DispatchAsync(Type handlerType, IEvent @event)
        {
            if(_context.TryResolve(handlerType, out object handler))
            {
                var method = handler.GetType().GetMethod("HandleAsync");
                await (Task)method.Invoke(handler, new object[] { @event });
            }
        }
    }
}