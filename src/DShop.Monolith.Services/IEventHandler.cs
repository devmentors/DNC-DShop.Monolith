using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;

namespace DShop.Monolith.Services
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}