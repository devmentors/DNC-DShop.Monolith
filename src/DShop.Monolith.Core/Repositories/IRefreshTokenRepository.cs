using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;

namespace DShop.Monolith.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task CreateAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}