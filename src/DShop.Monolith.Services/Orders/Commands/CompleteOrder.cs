using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Orders.Commands
{
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
