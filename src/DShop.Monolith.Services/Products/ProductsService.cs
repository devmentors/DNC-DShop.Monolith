using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Products;
using DShop.Monolith.Core.Domain.Products.Repositories;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Products.Dtos;
using DShop.Monolith.Services.Products.Queries;

namespace DShop.Monolith.Services.Products
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
                Description = product.Description,
                Vendor = product.Vendor,
                Price = product.Price
            };
        }

        public async Task<IPagedResult<ProductDto>> BrowseAsync(BrowseProducts query)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAsync(IEnumerable<Guid> ids)
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
                throw new ServiceException("Maybe we shall introduce some maybe pattern or derived exceptions?");
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