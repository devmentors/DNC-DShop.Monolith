using System;

namespace DShop.Monolith.Services.DTO
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
