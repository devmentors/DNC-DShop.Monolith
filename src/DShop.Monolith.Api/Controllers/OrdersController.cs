using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DShop.Monolith.Api.Framework;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Services.Orders.Commands;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services;
using DShop.Monolith.Services.Orders;
using DShop.Monolith.Services.Orders.Queries;

namespace DShop.Monolith.Api.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(ICommandDispatcher commandDispatcher,
            IOrdersService ordersService) : base(commandDispatcher)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
           => Collection(await _ordersService.BrowseAsync(query.Bind(q => q.CustomerId, UserId)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _ordersService.GetAsync(id), x => x.CustomerId == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrder command)
            => await DispatchAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, [FromBody] CompleteOrder command)
            => await DispatchAsync(command.Bind(c => c.Id, id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await DispatchAsync(new CancelOrder(id, UserId));
    }
}