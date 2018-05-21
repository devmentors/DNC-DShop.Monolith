using System;
using System.Threading.Tasks;
using DShop.Monolith.Infrastructure.Authentication;
using DShop.Monolith.Core.Types;
using Microsoft.AspNetCore.Identity;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Services.Dispatchers;
using System.Linq;
using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Identity.Factories;
using DShop.Monolith.Core.Domain.Identity.Repositories;
using DShop.Monolith.Core.Domain.Identity.Services;

namespace DShop.Monolith.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasher _hasher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserFactory _userFactory;
        private readonly IEventDispatcher _eventDispatcher;

        public IdentityService(IUserRepository userRepository,
            IHasher hasher,
            IJwtHandler jwtHandler,
            IRefreshTokenRepository refreshTokenRepository,
            IUserFactory userFactory,
            IEventDispatcher eventDispatcher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshTokenRepository;
            _userFactory = userFactory;
            _eventDispatcher = eventDispatcher;
        }

        public async Task SignUpAsync(Guid id, string email, string password, string role)
        {
            var user = await _userFactory.CreateAsync(id, email, password, role);
            await _userRepository.CreateAsync(user);
            await _eventDispatcher.DispatchAsync(user.Events.ToArray());
        }

        public async Task<IdentityToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !_hasher.IsValid(user, password))
            {
                throw new ServiceException("invalid_credentials",
                    "Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            var token = _hasher.Create(user, user.Id.ToString("N"), "=", "+", "\\");
            await _refreshTokenRepository.CreateAsync(new RefreshToken(user, token));

            return new IdentityToken
            {
                AccessToken = jwt.AccessToken,
                Expires = jwt.Expires,
                RefreshToken = token,
                Role = user.Role,
                UserId = user.Id
            };
        }

        public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", 
                    $"User: '{userId}' was not found.");
            }
            if (!_hasher.IsValid(user, currentPassword))
            {
                throw new ServiceException("invalid_current_password", 
                    "Invalid current password.");
            }
            SetPassword(user, newPassword);
            await _userRepository.UpdateAsync(user);            
        }

        private void SetPassword(User user, string password)
        {
            var passwordHash = _hasher.Create(user, password);
            user.SetPasswordHash(passwordHash);
        }
    }
}