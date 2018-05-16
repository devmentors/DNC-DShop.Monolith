using Newtonsoft.Json;

namespace DShop.Monolith.Services.Identity.Commands
{
    public class SignIn : ICommand
    {
        public string Email { get; }
        public string Password { get; }

        [JsonConstructor]
        public SignIn(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}