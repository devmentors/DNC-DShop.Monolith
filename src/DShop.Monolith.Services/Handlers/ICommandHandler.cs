using System.Threading.Tasks;
using DShop.Monolith.Services.Commands;

namespace DShop.Monolith.Services.Handlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}