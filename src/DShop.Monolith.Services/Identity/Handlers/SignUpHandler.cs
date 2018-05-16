using System.Threading.Tasks;
using DShop.Monolith.Services.Identity.Commands;

namespace DShop.Monolith.Services.Identity.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task HandleAsync(SignUp command)
            => await _identityService.SignUpAsync(command.Id, 
                command.Email, command.Password, command.Role);
    }
}