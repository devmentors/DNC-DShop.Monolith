using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Services.Orders.Dtos;
using DShop.Monolith.Services.Orders.Queries;

namespace DShop.Monolith.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrderDto> GetAsync(Guid id);
        Task<IPagedResult<OrderDto>> BrowseAsync(BrowseOrders browseOrders);
        Task CreateAsync(Guid id, Guid customerId, long number, 
            IEnumerable<Guid> productIds, decimal totalAmount, string currency);
        Task CompleteAsync(Guid id);
        Task CancelAsync(Guid id);
    }
}
