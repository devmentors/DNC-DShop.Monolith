using System;
using System.Collections.Generic;
using System.Linq;

namespace DShop.Monolith.Core.Domain
{
    public class Cart : EntityBase, IAggregateRoot
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

        public Cart(Guid userId)
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
                item.IncreaseQuantity(quantity);

                return;
            }
            item = new CartItem(product, quantity);
            _items.Add(item);
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
            if (item == null)
            {
                return;
            }
            item.Update(product);
        }

        private CartItem GetCartItem(Guid productId)
            => _items.SingleOrDefault(x => x.ProductId == productId);
    }
}