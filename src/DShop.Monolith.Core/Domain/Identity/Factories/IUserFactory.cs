using System;
using System.Threading.Tasks;

namespace DShop.Monolith.Core.Domain.Identity.Factories
{
    public interface IUserFactory
    {
        Task<User> CreateAsync(Guid id, string email, string password, string role = Role.User);
    }
}