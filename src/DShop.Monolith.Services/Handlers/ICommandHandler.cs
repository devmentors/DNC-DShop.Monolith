using System.Threading.Tasks;
using DShop.Monolith.Services.Commands;

namespace DShop.Monolith.Services.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}