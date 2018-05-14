using System;
using DShop.Monolith.Infrastructure.Types;

namespace DShop.Monolith.Services.Queries
{
    public class BrowseOrders : PagedQueryBase
    {
        public Guid CustomerId { get; set; }
    }
}