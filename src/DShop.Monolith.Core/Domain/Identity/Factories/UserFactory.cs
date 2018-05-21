using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Identity.Repositories;
using DShop.Monolith.Core.Domain.Identity.Services;
using DShop.Monolith.Core.Domain.Identity.Specifications;

namespace DShop.Monolith.Core.Domain.Identity.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IUniqueEmailSpecification _uniqueEmailSpecification;
        private readonly IHasher _hasher;

        public UserFactory(IUserRepository userRepository,
            IUniqueEmailSpecification uniqueEmailSpecification,
            IHasher hasher)
        {
            _userRepository = userRepository;
            _uniqueEmailSpecification = uniqueEmailSpecification;
            _hasher = hasher;
        }

        public async Task<User> CreateAsync(Guid id, string email, string password, string role = Role.User)
        {
            var isEmailUnique = await _uniqueEmailSpecification.IsSatisfiedByAsync(email);
            if (!isEmailUnique)
            {
                throw new DomainException("email_in_use",
                    $"Email: '{email}' is already in use.");
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                role = Role.User;
            }
            var user = new User(id, email, role);
            user.SetPasswordHash(_hasher.Create(user, password));

            return user;
        }
    }
}