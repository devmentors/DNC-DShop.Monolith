using System;

namespace DShop.Monolith.Core.Domain
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}