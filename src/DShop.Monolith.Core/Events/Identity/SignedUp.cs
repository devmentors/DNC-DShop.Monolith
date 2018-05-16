using System;

namespace DShop.Monolith.Core.Events.Identity
{
    public class SignedIn : IEvent
    {
        public Guid UserId { get;  }

        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}