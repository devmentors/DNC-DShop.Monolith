using System;
using System.Threading.Tasks;
using DShop.Monolith.Services.DTO;

namespace DShop.Monolith.Services.Services
{
    public interface ICartService
    {
        Task<CartDto> GetAsync(Guid userId);
        Task AddProductAsync(Guid userId, Guid productId, int quantity = 1);
        Task DeleteProductAsync(Guid userId, Guid productId);
        Task ClearAsync(Guid userId);
        Task HandleUpdatedProductAsync(Guid productId); 
        Task HandleDeletedProductAsync(Guid productId);    
    }
}