namespace DShop.Monolith.Core.Types
{
    public abstract class PagedQueryBase
    {
        public int Page { get; set; }
        public int Results { get; set; }
        public string OrderBy { get; set; }
        public string SortOrder { get; set; }
    }
}