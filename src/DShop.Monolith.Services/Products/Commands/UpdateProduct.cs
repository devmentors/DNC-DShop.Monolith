using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Products.Commands
{
	public class UpdateProduct : ICommand
	{
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public UpdateProduct(Guid id, string name, string description, string vendor, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}