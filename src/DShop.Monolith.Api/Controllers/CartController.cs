using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services;
using DShop.Monolith.Services.Customers;

namespace DShop.Monolith.Api.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICommandDispatcher commandDispatcher,
            ICartService cartService) : base(commandDispatcher)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Single(await _cartService.GetAsync(UserId));

        [HttpPost("items")]
        public async Task<IActionResult> Post([FromBody] AddProductToCart command)
            => await DispatchAsync(command.Bind(c => c.CustomerId, UserId));

        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
            => await DispatchAsync(new DeleteProductFromCart(UserId, productId));

        [HttpDelete("clear")]
        public async Task<IActionResult> Clear()
            => await DispatchAsync(new ClearCart(UserId));
    }
}