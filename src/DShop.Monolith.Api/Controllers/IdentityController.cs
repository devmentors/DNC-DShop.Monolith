using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DShop.Monolith.Infrastructure.Mvc;
using DShop.Monolith.Services.Commands;
using DShop.Monolith.Services.Commands.Identity;
using DShop.Monolith.Services;

namespace DShop.Monolith.Api.Controllers
{
    [Route("")]
    [AllowAnonymous]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ICustomersService _customersService;

        public IdentityController(ICommandDispatcher commandDispatcher,
            IIdentityService identityService,
            ICustomersService customersService,
            IRefreshTokenService refreshTokenService) : base(commandDispatcher)
        {
            _identityService = identityService;
            _customersService = customersService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
            => await DispatchAsync(command);

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPost("refresh-tokens/{refreshToken}/refresh")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
            => Ok(await _refreshTokenService.CreateAccessTokenAsync(refreshToken));
    }
}