using System;

namespace DShop.Monolith.Core.Domain.Customers
{
    public class Product : IValueObject
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        protected Product()
        {
        }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public static Product Create(Guid id, string name, decimal price)
            => new Product(id, name, price);
    }
}