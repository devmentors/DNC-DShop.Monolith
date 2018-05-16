using System.Threading.Tasks;
using DShop.Monolith.Core.Events;

namespace DShop.Monolith.Services
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}