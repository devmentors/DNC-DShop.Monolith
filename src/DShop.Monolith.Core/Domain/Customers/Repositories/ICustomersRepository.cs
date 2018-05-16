using System;
using System.Threading.Tasks;

namespace DShop.Monolith.Core.Domain.Customers.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}