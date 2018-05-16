using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Orders.Commands
{
    public class CreateOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CreateOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
