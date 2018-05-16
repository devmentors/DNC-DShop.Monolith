using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Orders;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Orders.Queries;
using DShop.Monolith.Services.Orders.Dtos;
using DShop.Monolith.Core.Domain.Orders.Repositories;

namespace DShop.Monolith.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await _ordersRepository.GetAsync(id);

            return order == null ? null : new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                ProductIds = order.ProductIds,
                Number = order.Number,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                Currency = order.Currency
            };
        }

        public async Task<IPagedResult<OrderDto>> BrowseAsync(BrowseOrders browseOrders)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Guid id, Guid customerId, long number, IEnumerable<Guid> productIds, decimal totalAmount, string currency)
        {
            var order = new Order(id, customerId, number, productIds, totalAmount, currency);
            await _ordersRepository.CreateAsync(order);
        }

        public async Task CompleteAsync(Guid id)
            => await ChangeStatusAsync(id, order => order.Complete());

        public async Task CancelAsync(Guid id)
            => await ChangeStatusAsync(id, order => order.Cancel());

        private async Task ChangeStatusAsync(Guid id, Action<Order> changeStatus)
        {
            var order = await _ordersRepository.GetAsync(id);
            if (order == null)
            {
                throw new ServiceException("Order not found.");
            }
            changeStatus(order);
            await _ordersRepository.UpdateAsync(order);
        }
    }
}
