using System;
using System.Threading.Tasks;
using DShop.Monolith.Infrastructure.Authentication;

namespace DShop.Monolith.Services.Identity
{
    public interface IRefreshTokenService
    {
        Task CreateAsync(Guid userId);
        Task<IdentityToken> CreateAccessTokenAsync(string refreshToken);
        Task RevokeAsync(string refreshToken, Guid userId);
    }
}