using System.Threading.Tasks;
using DShop.Monolith.Services.Commands.Customers;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Handlers.Customers
{
    public class ClearCartHandler : ICommandHandler<ClearCart>
    {
        private readonly IHandler _handler;
        private readonly ICartService _cartService;

        public ClearCartHandler(IHandler handler, ICartService cartService)
        {
            _handler = handler;
            _cartService = cartService;
        }

        public async Task HandleAsync(ClearCart command)
            => await _cartService.ClearAsync(command.CustomerId);
    }
}