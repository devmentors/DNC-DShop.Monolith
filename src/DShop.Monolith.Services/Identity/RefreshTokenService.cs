using System;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Repositories;
using DShop.Monolith.Core.Types;
using DShop.Monolith.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DShop.Monolith.Services.Identity
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            IJwtHandler jwtHandler,
            IPasswordHasher<User> passwordHasher)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", 
                    $"User: '{userId}' was not found.");
            }
            var token = CreateToken(user, _passwordHasher);
            await _refreshTokenRepository.CreateAsync(new RefreshToken(user, token));
        }

        public async Task<JsonWebToken> CreateAccessTokenAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null)
            {
                throw new ServiceException("refresh_token_not_found", 
                    "Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new ServiceException("refresh_token_not_revoked", 
                    $"Refresh token: '{refreshToken.Id}' was revoked.");
            }
            var user = await _userRepository.GetAsync(refreshToken.UserId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", 
                    $"User: '{refreshToken.UserId}' was not found.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            jwt.RefreshToken = refreshToken.Token;
            
            return jwt;
        }

        public async Task RevokeAsync(string token, Guid userId)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null || refreshToken.UserId != userId)
            {
                throw new ServiceException("refresh_token_not_revoked", 
                    "Refresh token was not found.");
            }
            refreshToken.Revoke();
            await _refreshTokenRepository.UpdateAsync(refreshToken);
        }

        private static string CreateToken(User user, IPasswordHasher<User> passwordHasher)
            => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N"))
                .Replace("=", string.Empty)
                .Replace("+", string.Empty)
                .Replace("/", string.Empty);
    }
}