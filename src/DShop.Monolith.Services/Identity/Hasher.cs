using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace DShop.Monolith.Services.Identity
{
    public class Hasher : IHasher
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public Hasher(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string Create(User user, string secret, params string[] excludedChars)
        {
            var hash = _passwordHasher.HashPassword(user, secret);
            if (excludedChars != null)
            {
                foreach (var excludedChar in excludedChars)
                {
                    hash = hash.Replace(excludedChar, string.Empty);
                }
            }

            return hash;
        }

        public bool IsValid(User user, string secret)
            => _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, secret) != PasswordVerificationResult.Failed; 
    }
}