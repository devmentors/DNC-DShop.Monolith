namespace DShop.Monolith.Api.Framework
{
    public class AdminAuthAttribute : AuthAttribute
    {
        public AdminAuthAttribute() : base("admin")
        {
        }
    }
}