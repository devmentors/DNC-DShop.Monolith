using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Monolith.Infrastructure.Types;
using DShop.Monolith.Services.DTO;
using DShop.Monolith.Services.Queries;

namespace DShop.Monolith.Services
{
    public interface IOrdersService
    {
        Task<OrderDto> GetAsync(Guid id);
        Task<PagedResult<OrderDto>> BrowseAsync(BrowseOrders browseOrders);
        Task CreateAsync(Guid id, Guid customerId, long number, 
            IEnumerable<Guid> productIds, decimal totalAmount, string currency);
        Task CompleteAsync(Guid id);
        Task CancelAsync(Guid id);
    }
}
