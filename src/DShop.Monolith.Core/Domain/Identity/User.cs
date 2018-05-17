using System;
using System.Text.RegularExpressions;
using DShop.Monolith.Core.Domain.Identity.Events;

namespace DShop.Monolith.Core.Domain.Identity
{
    public class User : AggregateRoot
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            
        public string Email { get; protected set; }
        public string Role { get; protected set; }
        public string PasswordHash { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid id, string email, string role) : base(id)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new DomainException("invalid_email", 
                    $"Invalid email: '{email}'.");
            }
            if (!Identity.Role.IsValid(role))
            {
                throw new DomainException("invalid_role", 
                    $"Invalid role: '{role}'.");
            }        
            Email = email.ToLowerInvariant();
            Role = role.ToLowerInvariant();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            AddEvent(new SignedUp(id, email, role));
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}