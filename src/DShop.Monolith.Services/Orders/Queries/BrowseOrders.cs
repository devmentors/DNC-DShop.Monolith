using System;
using DShop.Monolith.Core.Types;

namespace DShop.Monolith.Services.Orders.Queries
{
    public class BrowseOrders : PagedQueryBase
    {
        public Guid CustomerId { get; set; }
    }
}