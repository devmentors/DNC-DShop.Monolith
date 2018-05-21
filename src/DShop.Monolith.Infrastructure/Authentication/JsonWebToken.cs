using System;

namespace DShop.Monolith.Infrastructure.Authentication
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
    }
}