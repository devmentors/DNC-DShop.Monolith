using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;

namespace DShop.Monolith.Services.Dispatchers
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(params IEvent[] events);
    }
}