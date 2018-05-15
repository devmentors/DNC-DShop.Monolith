using System.Threading.Tasks;
using DShop.Monolith.Core.Events.Identity;

namespace DShop.Monolith.Services.Handlers.Identity
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly ICustomersService _customersService;

        public SignedUpHandler(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public async Task HandleAsync(SignedUp @event)
        {
            await _customersService.CreateAsync(@event.Id, @event.Email);
        }
    }
}