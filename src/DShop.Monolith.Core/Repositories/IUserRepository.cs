using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Identity;

namespace DShop.Monolith.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}