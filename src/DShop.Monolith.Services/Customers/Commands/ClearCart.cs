using System;
using Newtonsoft.Json;

namespace DShop.Monolith.Services.Customers.Commands
{
    public class ClearCart : ICommand
    {
        public Guid CustomerId { get; }

        [JsonConstructor]
        public ClearCart(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}