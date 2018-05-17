using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services.Dispatchers;
using DShop.Monolith.Services.Identity.Commands;
using DShop.Monolith.Services;
using DShop.Monolith.Services.Identity;

namespace DShop.Monolith.Api.Controllers
{
    [Route("")]
    [AllowAnonymous]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly IRefreshTokenService _refreshTokenService;

        public IdentityController(ICommandDispatcher commandDispatcher,
            IIdentityService identityService, IRefreshTokenService refreshTokenService) : base(commandDispatcher)
        {
            _identityService = identityService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
            => await DispatchAsync(command.BindId(c => c.Id));

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPost("refresh-tokens/{refreshToken}/refresh")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
            => Ok(await _refreshTokenService.CreateAccessTokenAsync(refreshToken));
    }
}