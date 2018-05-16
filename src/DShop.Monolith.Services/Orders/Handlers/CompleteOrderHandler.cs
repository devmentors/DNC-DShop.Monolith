using DShop.Monolith.Services.Orders.Commands;
using System.Threading.Tasks;

namespace DShop.Monolith.Services.Orders.Handlers
{
    public sealed class CompleteOrderHandler : ICommandHandler<CompleteOrder>
    {
        private readonly IOrdersService _ordersService;

        public CompleteOrderHandler(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task HandleAsync(CompleteOrder command)
            => await _ordersService.CompleteAsync(command.Id);
    }
}
