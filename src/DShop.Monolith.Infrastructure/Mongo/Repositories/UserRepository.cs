using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Identity.Repositories;

namespace DShop.Monolith.Infrastructure.Mongo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<User> _repository;

        public UserRepository(IMongoRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task<User> GetAsync(string email)
            => await _repository.GetAsync(x => x.Email == email.ToLowerInvariant());

        public async Task<bool> IsEmailUnique(string email)
            => await _repository.ExistsAsync(x => x.Email == email.ToLowerInvariant()) == false;

        public async Task CreateAsync(User user)
            => await _repository.CreateAsync(user);

        public async Task UpdateAsync(User user)
            => await _repository.UpdateAsync(user);
    }
}