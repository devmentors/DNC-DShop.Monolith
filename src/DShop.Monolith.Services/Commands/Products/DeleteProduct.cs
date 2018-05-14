using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Commands.Products
{
	public class DeleteProduct : ICommand
	{
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteProduct(Guid id)
        {
            Id = id;
        }
	}
}