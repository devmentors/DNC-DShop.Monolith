using System;
using System.Linq;
using System.Threading.Tasks;
using DShop.Monolith.Services.Customers;
using DShop.Monolith.Services.Orders.Commands;
using DShop.Monolith.Services.Products;

namespace DShop.Monolith.Services.Orders.Handlers
{
    public sealed class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly ICartService _cartService;
        private readonly IOrdersService _ordersService;
        private readonly IProductsService _productsService;

        public CreateOrderHandler(ICartService cartService, IOrdersService ordersService, IProductsService productsService)
        {
            _cartService = cartService;
            _ordersService = ordersService;
            _productsService = productsService;
        }

        public async Task HandleAsync(CreateOrder command)
        {
            var cart = await _cartService.GetAsync(command.CustomerId);
            var productIds = cart.Items.Select(i => i.ProductId);
            var products = await _productsService.GetAsync(productIds);
            var totalAmount = products.Sum(p =>
            {
                var quantity = cart.Items.FirstOrDefault(i => i.ProductId == p.Id).Quantity;
                return quantity * p.Price;
            });
            var orderNumber = new Random().Next(); 
            await _ordersService.CreateAsync(command.Id, command.CustomerId, orderNumber, productIds, totalAmount, "USD");
        }
    }
}
