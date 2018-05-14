using System;
using Newtonsoft.Json;

namespace DShop.Monolith.Services.Commands.Customers
{
    public class DeleteProductFromCart : ICommand
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        [JsonConstructor]
        public DeleteProductFromCart(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}