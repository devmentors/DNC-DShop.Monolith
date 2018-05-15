using System.Threading.Tasks;
using DShop.Monolith.Core.Events.Customers;

namespace DShop.Monolith.Services.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        public async Task HandleAsync(CustomerCreated @event)
        {
            throw new System.NotImplementedException();
        }
    }
}