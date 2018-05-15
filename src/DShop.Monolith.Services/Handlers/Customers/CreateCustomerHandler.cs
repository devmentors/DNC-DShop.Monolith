using System.Threading.Tasks;
using DShop.Monolith.Services.Commands.Customers;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Handlers.Customers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomersService _customerService;
        private readonly IHandler _handler;

        public CreateCustomerHandler(ICustomersService customerService,
            IHandler handler)
        {
            _customerService = customerService;
            _handler = handler;
        }

        public async Task HandleAsync(CreateCustomer command)
            => await _customerService.CompleteAsync(command.Id, command.FirstName, 
                        command.LastName, command.Address, command.Country);
    }
}