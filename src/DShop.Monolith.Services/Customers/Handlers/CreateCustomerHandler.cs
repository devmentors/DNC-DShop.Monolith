using System.Threading.Tasks;
using DShop.Monolith.Services.Customers.Commands;
using DShop.Monolith.Services;

namespace DShop.Monolith.Services.Customers.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomersService _customerService;

        public CreateCustomerHandler(ICustomersService customerService)
        {
            _customerService = customerService;
        }

        public async Task HandleAsync(CreateCustomer command)
            => await _customerService.CompleteAsync(command.Id, command.FirstName, 
                    command.LastName, command.Address, command.Country);
    }
}