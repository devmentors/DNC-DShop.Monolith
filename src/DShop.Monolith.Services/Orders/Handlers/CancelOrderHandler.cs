using DShop.Monolith.Services.Orders.Commands;
using System.Threading.Tasks;

namespace DShop.Monolith.Services.Orders.Handlers
{
    public sealed class CancelOrderHandler : ICommandHandler<CancelOrder>
    {
        private readonly IOrdersService _ordersService;

        public CancelOrderHandler(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task HandleAsync(CancelOrder command)
            => await _ordersService.CancelAsync(command.Id);               
    }
}
