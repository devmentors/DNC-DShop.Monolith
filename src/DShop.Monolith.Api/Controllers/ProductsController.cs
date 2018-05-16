using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Monolith.Api.Framework;
using DShop.Monolith.Services.Products.Commands;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services;
using DShop.Monolith.Services.Products;
using DShop.Monolith.Services.Products.Queries;

namespace DShop.Monolith.Api.Controllers
{
    [AdminAuth]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(ICommandDispatcher commandDispatcher, 
            IProductsService productsService) : base(commandDispatcher)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseProducts query)
            => Collection(await _productsService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProduct command)
            => await DispatchAsync(command.BindId(c => c.Id), 
                resourceId: command.Id, resource: "products");

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(Guid id, [FromBody] UpdateProduct command)
            => await DispatchAsync(command.Bind(c => c.Id, id), 
                resourceId: command.Id, resource: "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await DispatchAsync(new DeleteProduct(id));
    }
}
