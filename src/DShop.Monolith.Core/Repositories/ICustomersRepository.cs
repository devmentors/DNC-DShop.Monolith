using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;

namespace DShop.Monolith.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}