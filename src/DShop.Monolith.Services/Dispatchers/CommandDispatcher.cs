using System;
using System.Threading.Tasks;
using Autofac;

namespace DShop.Monolith.Services.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            var handler = _context.Resolve<ICommandHandler<T>>();
            if (handler == null)
            {
                throw new ArgumentException($"Command handler: '{typeof(T).Name}' was not found.",
                    nameof(handler));
            }
            await handler.HandleAsync(command);
        }
    }
}