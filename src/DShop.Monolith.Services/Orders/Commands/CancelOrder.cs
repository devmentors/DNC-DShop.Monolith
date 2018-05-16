using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Orders.Commands
{
    public class CancelOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CancelOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
