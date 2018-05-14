using Autofac;
using DShop.Monolith.Infrastructure.Options;
using Microsoft.Extensions.Configuration;

namespace DShop.Monolith.Infrastructure.MailKit
{
    public static class Extensions
    {
        public static void AddMailKit(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MailKitOptions>("mailkit");
                return options;

            }).SingleInstance();
        }
    }
}
