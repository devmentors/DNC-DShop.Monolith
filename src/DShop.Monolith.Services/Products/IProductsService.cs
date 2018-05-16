using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Products.Dtos;
using DShop.Monolith.Services.Products.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Monolith.Services.Products
{
    public interface IProductsService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAsync(IEnumerable<Guid> ids);
        Task<IPagedResult<ProductDto>> BrowseAsync(BrowseProducts query);
        Task CreateAsync(Guid id, string name, string description, string vendor, decimal price);
        Task UpdateAsync(Guid id, string name, string description, decimal price);
        Task DeleteAsync(Guid id);
    }
}