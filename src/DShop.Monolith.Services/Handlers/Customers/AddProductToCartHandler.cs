using System.Threading.Tasks;
using DShop.Monolith.Services.Commands.Customers;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Handlers.Customers
{
    public class AddProductToCartHandler : ICommandHandler<AddProductToCart>
    {
        private readonly IHandler _handler;
        private readonly ICartService _cartService;

        public AddProductToCartHandler(IHandler handler, ICartService cartService)
        {
            _handler = handler;
            _cartService = cartService;
        }

        public async Task HandleAsync(AddProductToCart command)
            => await _cartService.AddProductAsync(command.CustomerId, command.ProductId, command.Quantity);
    }
}