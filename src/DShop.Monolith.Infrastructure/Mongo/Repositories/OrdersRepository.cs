using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Orders;
using DShop.Monolith.Core.Domain.Orders.Repositories;

namespace DShop.Monolith.Infrastructure.Mongo.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoRepository<Order> _repository;

        public OrdersRepository(IMongoRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task CreateAsync(Order order)
            => await _repository.CreateAsync(order);

        public async Task UpdateAsync(Order order)
            => await _repository.UpdateAsync(order);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);
    }
}
