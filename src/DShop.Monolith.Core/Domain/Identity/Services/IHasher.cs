namespace DShop.Monolith.Core.Domain.Identity.Services
{
    public interface IHasher
    {
        string Create(User user, string secret, params string[] excludedChars);
        bool IsValid(User user, string secret);
    }
}