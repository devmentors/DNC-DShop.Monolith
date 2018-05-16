using System;

namespace DShop.Monolith.Core.Domain.Identity
{
    public class RefreshToken : AggregateRoot
    {
        public Guid UserId { get; protected set; }
        public string Token { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? RevokedAt { get; protected set; }
        public bool Revoked => RevokedAt.HasValue;

        protected RefreshToken()
        {
        }

        public RefreshToken(User user, string token)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
            Token = token;
        }

        public void Revoke()
        {
            if (Revoked)
            {
                throw new DomainException("refresh_token_revoked", 
                    $"Refresh token: '{Id}' was already revoked at '{RevokedAt}'.");
            }
            RevokedAt = DateTime.UtcNow;
        }
    }
}