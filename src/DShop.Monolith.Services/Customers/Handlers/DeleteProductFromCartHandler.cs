using System.Threading.Tasks;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Customers.Handlers
{
    public class DeleteProductFromCartHandler : ICommandHandler<DeleteProductFromCart>
    {
        private readonly ICartService _cartService;

        public DeleteProductFromCartHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task HandleAsync(DeleteProductFromCart command)
            => await _cartService.DeleteProductAsync(command.CustomerId, command.ProductId);
    }
}