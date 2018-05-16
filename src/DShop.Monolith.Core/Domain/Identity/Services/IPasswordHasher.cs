namespace DShop.Monolith.Core.Domain.Identity.Services
{
    public interface IPasswordHasher
    {
        void SetPasswordHash(User user, string password);
    }
}