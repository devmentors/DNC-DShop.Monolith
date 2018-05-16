using System;

namespace DShop.Monolith.Core.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}