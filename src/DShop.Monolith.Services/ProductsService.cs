using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Repositories;
using DShop.Monolith.Infrastructure.Types;
using DShop.Monolith.Services.DTO;
using DShop.Monolith.Services.Queries;

namespace DShop.Monolith.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productsRepository.GetAsync(id);

            return product == null ? null : new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Descirption,
                Vendor = product.Vendor,
                Price = product.Price
            };
        }

        public async Task<PagedResult<ProductDto>> BrowseAsync(BrowseProducts query)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Guid id, string name, string description, string vendor, decimal price)
        {
            var product = new Product(id, name, description, vendor, price);
            await _productsRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(Guid id, string name, string description, decimal price)
        {
            var product = await _productsRepository.GetAsync(id);

            if(product == null)
            {
                throw new DShopException("Maybe we shall introduce some maybe pattern or derived exceptions?");
            }

            product.SetName(name);
            product.SetDescription(description);
            product.SetPrice(price);

            await _productsRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
            => await _productsRepository.DeleteAsync(id);
    }
}