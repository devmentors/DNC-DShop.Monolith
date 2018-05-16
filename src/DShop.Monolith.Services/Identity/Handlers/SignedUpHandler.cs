using System.Threading.Tasks;
using DShop.Monolith.Core.Events.Identity;
using DShop.Monolith.Services.Customers;

namespace DShop.Monolith.Services.Identity.Handlers
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly ICustomersService _customersService;

        public SignedUpHandler(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task HandleAsync(SignedUp @event)
            => await _customersService.CreateAsync(@event.UserId, @event.Email);
    }
}