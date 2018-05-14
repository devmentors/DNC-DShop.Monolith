using System.Threading.Tasks;

namespace DShop.Monolith.Services.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}