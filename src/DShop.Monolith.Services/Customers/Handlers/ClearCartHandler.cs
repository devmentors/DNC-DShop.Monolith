using System.Threading.Tasks;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Customers.Handlers
{
    public class ClearCartHandler : ICommandHandler<ClearCart>
    {
        private readonly ICartService _cartService;

        public ClearCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task HandleAsync(ClearCart command)
            => await _cartService.ClearAsync(command.CustomerId);
    }
}