using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Customers;

namespace DShop.Monolith.Core.Repositories
{
    public interface ICartsRepository
    {
        Task<Cart> GetAsync(Guid id);
        Task<IEnumerable<Cart>> GetAllWithProduct(Guid productId);
        Task CreateAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task UpdateManyAsync(IEnumerable<Cart> carts);
    }
}