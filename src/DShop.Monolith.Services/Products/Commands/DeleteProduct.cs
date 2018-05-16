using Newtonsoft.Json;
using System;

namespace DShop.Monolith.Services.Products.Commands
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