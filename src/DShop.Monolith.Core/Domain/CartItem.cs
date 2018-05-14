using System;

namespace DShop.Monolith.Core.Domain
{
    public class CartItem : EntityBase
    {
        public Guid ProductId { get; protected set; }
        public string ProductName { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        protected CartItem()
        {
        }

        public CartItem(Product product, int quantity)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            UnitPrice = product.Price;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void Update(Product product)
        {
            ProductName = product.Name;
            UnitPrice = product.Price;
        }
    }
}