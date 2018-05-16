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

namespace DShop.Monolith.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserFactory _userFactory;
        private readonly IEventDispatcher _eventDispatcher;

        public IdentityService(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IJwtHandler jwtHandler,
            IRefreshTokenRepository refreshTokenRepository,
            IUserFactory userFactory,
            IEventDispatcher eventDispatcher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
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

        public async Task<JsonWebToken> SignInAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !ValidatePassword(user,password, _passwordHasher))
            {
                throw new ServiceException("invalid_credentials",
                    "Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

            return jwt;
        }

        public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException("user_not_found", 
                    $"User: '{userId}' was not found.");
            }
            if (!ValidatePassword(user, currentPassword, _passwordHasher))
            {
                throw new ServiceException("invalid_current_password", 
                    "Invalid current password.");
            }
            SetPassword(user, newPassword);
            await _userRepository.UpdateAsync(user);            
        }

        private void SetPassword(User user, string password)
        {
            var passwordHash = _passwordHasher.HashPassword(user, password);
            user.SetPasswordHash(passwordHash);
        }

        private static bool ValidatePassword(User user, string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}