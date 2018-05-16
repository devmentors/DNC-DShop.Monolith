using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Products;

namespace DShop.Monolith.Core.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}