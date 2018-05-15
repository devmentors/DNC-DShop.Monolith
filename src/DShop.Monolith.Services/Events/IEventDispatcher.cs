using System.Threading.Tasks;
using DShop.Monolith.Core.Events;

namespace DShop.Monolith.Services.Events
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(params IEvent[] events);
    }
}