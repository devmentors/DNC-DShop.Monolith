using DShop.Monolith.Services.Products.Commands;
using System.Threading.Tasks;

namespace DShop.Monolith.Services.Products.Handlers
{
    public class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly IProductsService _productsService;

        public DeleteProductHandler(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task HandleAsync(DeleteProduct command)
            => await _productsService.DeleteAsync(command.Id);
    }
}
