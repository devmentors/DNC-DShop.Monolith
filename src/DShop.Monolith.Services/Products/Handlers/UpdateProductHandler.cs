using System.Threading.Tasks;
using DShop.Monolith.Services.Products.Commands;

namespace DShop.Monolith.Services.Products.Handlers
{
    public sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
        private readonly IProductsService _productsService;


        public UpdateProductHandler(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task HandleAsync(UpdateProduct command)
            => await _productsService.UpdateAsync(command.Id, command.Name, 
                command.Description, command.Price);
    }
}
