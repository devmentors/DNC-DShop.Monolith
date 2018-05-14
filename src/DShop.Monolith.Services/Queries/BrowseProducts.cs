using DShop.Monolith.Infrastructure.Types;

namespace DShop.Monolith.Services.Queries
{
    public class BrowseProducts : PagedQueryBase
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; } = decimal.MaxValue;   
    }
}