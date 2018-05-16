using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Customers;
using DShop.Monolith.Core.Domain.Customers.Repositories;

namespace DShop.Monolith.Infrastructure.Mongo.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _repository;
        
        public CustomersRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task CreateAsync(Customer customer)
            => await _repository.CreateAsync(customer);

        public async Task UpdateAsync(Customer customer)
            => await _repository.UpdateAsync(customer);
    }
}