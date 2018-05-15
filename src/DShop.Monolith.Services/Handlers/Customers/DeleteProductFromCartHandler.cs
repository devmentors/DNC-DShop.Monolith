using System.Threading.Tasks;
using DShop.Monolith.Services.Commands.Customers;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Handlers.Customers
{
    public class DeleteProductFromCartHandler : ICommandHandler<DeleteProductFromCart>
    {
        private readonly IHandler _handler;
        private readonly ICartService _cartService;

        public DeleteProductFromCartHandler(IHandler handler, ICartService cartService)
        {
            _handler = handler;
            _cartService = cartService;
        }

        public async Task HandleAsync(DeleteProductFromCart command)
            => await _cartService.DeleteProductAsync(command.CustomerId, command.ProductId);
    }
}