using System;
using Newtonsoft.Json;

namespace DShop.Monolith.Services.Commands.Customers
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