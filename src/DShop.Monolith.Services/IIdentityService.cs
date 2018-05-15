using System;
using System.Threading.Tasks;
using DShop.Monolith.Infrastructure.Authentication;

namespace DShop.Monolith.Services
{
    public interface IIdentityService
    {
        Task SignUpAsync(Guid id, string email, string password, string role = "user");
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);         
    }
}