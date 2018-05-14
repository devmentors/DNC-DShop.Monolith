using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Infrastructure.Types;

namespace DShop.Monolith.Services.Handlers
{
    public interface IHandler
    {
        IHandler Handle(Func<Task> handle);
        IHandler OnSuccess(Func<Task> onSuccess);
        IHandler OnError(Func<Exception, Task> onError);
        IHandler OnDShopError(Func<DShopException, Task> onDShopError);
        Task ExecuteAsync();
    }
}