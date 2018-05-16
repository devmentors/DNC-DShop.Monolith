using DShop.Monolith.Core.Types;

namespace DShop.Monolith.Services.Products.Queries
{
    public class BrowseProducts : PagedQueryBase
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; } = decimal.MaxValue;   
    }
}