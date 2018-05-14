using System;
using System.Collections.Generic;

namespace DShop.Monolith.Services.DTO
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; }
    }
}
