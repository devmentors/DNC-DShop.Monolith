using System;
using System.Collections.Generic;
using System.Linq;

namespace DShop.Monolith.Core.Domain.Customers
{
    public class Cart : AggregateRoot
    {
        private ISet<CartItem> _items = new HashSet<CartItem>();
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<CartItem> Items
        {
            get => _items;
            set => _items = new HashSet<CartItem>(value);
        }

        protected Cart()
        {
        }

        public Cart(Guid userId) : base(userId)
        {
            Id = userId;
            CreatedAt = DateTime.UtcNow;
        }
        
        public void Clear()
            => _items.Clear();

        public void AddProduct(Product product, int quantity)
        {
            var item = GetCartItem(product.Id);
            if (item != null)
            {
                _items.Remove(item);
            }
            _items.Add(CartItem.Create(product, quantity));
        }

        public void DeleteProduct(Guid productId)
        {
            var item = GetCartItem(productId);
            if (item == null)
            {
                return;
            }
            _items.Remove(item);
        }

        public void UpdateProduct(Product product)
        {
            var item = GetCartItem(product.Id);
            if (item != null)
            {
                _items.Remove(item);
            }
            _items.Add(CartItem.Create(product, item.Quantity));
        }

        private CartItem GetCartItem(Guid productId)
            => _items.SingleOrDefault(x => x.ProductId == productId);
    }
}