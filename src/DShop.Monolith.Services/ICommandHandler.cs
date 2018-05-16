using System.Threading.Tasks;

namespace DShop.Monolith.Services
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}