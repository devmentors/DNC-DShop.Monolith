using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace DShop.Monolith.Services.Identity
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordHasher(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public void SetPasswordHash(User user, string password)
        {
            var passwordHash = _passwordHasher.HashPassword(user, password);
            user.SetPasswordHash(passwordHash);
        }
    }
}