using DShop.Monolith.Infrastructure.Types;
using DShop.Monolith.Services.DTO;
using DShop.Monolith.Services.Queries;
using System;
using System.Threading.Tasks;

namespace DShop.Monolith.Services.Products.Services
{
    public interface IProductsService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task<PagedResult<ProductDto>> BrowseAsync(BrowseProducts query);
        Task CreateAsync(Guid id, string name, string description, string vendor, decimal price);
        Task UpdateAsync(Guid id, string name, string description, decimal price);
        Task DeleteAsync(Guid id);
    }
}