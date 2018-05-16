using System.Threading.Tasks;
using DShop.Monolith.Services.Products.Commands;

namespace DShop.Monolith.Services.Products.Handlers
{
    public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductsService _productsService;

        public CreateProductHandler(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task HandleAsync(CreateProduct command)
            => await _productsService.CreateAsync(command.Id, command.Name, 
                command.Description, command.Vendor, command.Price);
    }
}
