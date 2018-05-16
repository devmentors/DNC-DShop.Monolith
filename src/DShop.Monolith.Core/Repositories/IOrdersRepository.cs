using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Orders;

namespace DShop.Monolith.Core.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetAsync(Guid id);
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
    }
}
