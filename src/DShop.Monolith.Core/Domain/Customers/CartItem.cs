using System;

namespace DShop.Monolith.Core.Domain.Customers
{
    public class CartItem : IValueObject
    {
        public Guid ProductId { get; protected set; }
        public string ProductName { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        protected CartItem()
        {
        }

        protected CartItem(Product product, int quantity)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            UnitPrice = product.Price;
            Quantity = quantity;
        }

        public static CartItem Create(Product product, int quantity)
            => new CartItem(product, quantity);
    }
}