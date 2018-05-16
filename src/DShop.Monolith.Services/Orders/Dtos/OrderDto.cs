using System;
using System.Collections.Generic;

namespace DShop.Monolith.Services.Orders.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public long Number { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
