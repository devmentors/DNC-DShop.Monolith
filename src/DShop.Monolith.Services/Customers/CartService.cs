using System;
using System.Linq;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Customers;
using DShop.Monolith.Core.Domain.Customers.Repositories;
using DShop.Monolith.Core.Domain.Products.Repositories;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Carts.Dtos;

namespace DShop.Monolith.Services.Customers
{
    public class CartService : ICartService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IProductsRepository _productsRepository;

        public CartService(ICartsRepository cartsRepository,
            IProductsRepository productsRepository)
        {
            _cartsRepository = cartsRepository;
            _productsRepository = productsRepository;
        }

        public async Task<CartDto> GetAsync(Guid userId)
        {
            var cart = await _cartsRepository.GetAsync(userId);

            return cart == null ? null : new CartDto
            {
                Id = cart.Id,
                Items = cart.Items.Select(x => new CartItemDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                })
            };
        }

        public async Task AddProductAsync(Guid userId, Guid productId, int quantity = 1)
        {
            var product = await _productsRepository.GetAsync(productId);
            if (product == null)
            {
                throw new ServiceException("product_not_found", 
                    $"Product: '{productId}' was not found.");
            }
            var cart = await _cartsRepository.GetAsync(userId);
            cart.AddProduct(Product.Create(product.Id, product.Name, product.Price), quantity);
            await _cartsRepository.UpdateAsync(cart);
        }

        public async Task DeleteProductAsync(Guid userId, Guid productId)
        {
            var cart = await _cartsRepository.GetAsync(userId);
            cart.DeleteProduct(productId);
            await _cartsRepository.UpdateAsync(cart);
        }

        public async Task ClearAsync(Guid userId)
        {
            var cart = await _cartsRepository.GetAsync(userId);
            cart.Clear();
            await _cartsRepository.UpdateAsync(cart);
        }

        public async Task HandleUpdatedProductAsync(Guid productId)
        {
            var product = await _productsRepository.GetAsync(productId);
            var carts = await _cartsRepository.GetAllWithProduct(productId);
            foreach (var cart in carts)
            {
                cart.UpdateProduct(Product.Create(product.Id, product.Name, product.Price));
            }
            await _cartsRepository.UpdateManyAsync(carts);
        }

        public async Task HandleDeletedProductAsync(Guid productId)
        {
            var carts = await _cartsRepository.GetAllWithProduct(productId);
            foreach (var cart in carts)
            {
                cart.DeleteProduct(productId);
            }
            await _cartsRepository.UpdateManyAsync(carts);
        }
    }
}