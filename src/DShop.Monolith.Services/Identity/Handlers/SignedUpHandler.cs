using System.Threading.Tasks;
using DShop.Monolith.Core.Domain.Identity.Events;
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