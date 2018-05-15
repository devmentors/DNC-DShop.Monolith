using System;

namespace DShop.Monolith.Core.Events.Identity
{
    public class SignedUp : IEvent
    {
        public Guid Id { get;  }
        public string Email { get; }
        public string Role { get; }

        public SignedUp(Guid id, string email, string role)
        {
            Id = id;
            Email = email;
            Role = role;
        }
    }
}