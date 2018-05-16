using DShop.Monolith.Services.Dispatchers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Monolith.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("DShop API");
    }
}