using System.Threading.Tasks;
using DShop.Monolith.Services.Customers;
using DShop.Monolith.Services.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Monolith.Api.Controllers
{
    [Route("")]
    public class AccountController : BaseController
    {
        private readonly ICustomersService _customersService;

        public AccountController(ICommandDispatcher commandDispatcher,
            ICustomersService customersService) : 
            base(commandDispatcher)
        {
            _customersService = customersService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> Get()
            => Single(await _customersService.GetAsync(UserId));
    }
}