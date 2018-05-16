using DShop.Monolith.Core.Types;

namespace DShop.Monolith.Services.Products.Queries
{
    public class BrowseProducts : PagedQuery
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; } = decimal.MaxValue;   
    }
}