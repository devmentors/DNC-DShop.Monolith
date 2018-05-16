using System.Threading.Tasks;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Customers.Handlers
{
    public class AddProductToCartHandler : ICommandHandler<AddProductToCart>
    {
        private readonly ICartService _cartService;

        public AddProductToCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task HandleAsync(AddProductToCart command)
            => await _cartService.AddProductAsync(command.CustomerId, command.ProductId, command.Quantity);
    }
}