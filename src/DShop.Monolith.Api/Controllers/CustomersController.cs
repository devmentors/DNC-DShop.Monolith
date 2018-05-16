using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Monolith.Api.Framework;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services;
using DShop.Monolith.Services.Customers;
using DShop.Monolith.Services.Customers.Queries;

namespace DShop.Monolith.Api.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICommandDispatcher commandDispatcher,
            ICustomersService customersService) : base(commandDispatcher)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [AdminAuth]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _customersService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _customersService.GetAsync(id), x => x.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
            => await DispatchAsync(command.Bind(c => c.Id, UserId), 
                resourceId: command.Id, resource: "customers");
    }
}
