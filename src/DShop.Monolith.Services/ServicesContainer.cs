using System.Reflection;
using Autofac;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Identity.Factories;
using DShop.Monolith.Core.Domain.Identity.Specifications;
using DShop.Monolith.Core.Types;
using Microsoft.AspNetCore.Identity;

namespace DShop.Monolith.Services
{
    public static class ServicesContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var servicesAssembly = Assembly.GetExecutingAssembly();
            var coreAssembly = Assembly.GetAssembly(typeof(IEntity));
            builder.RegisterAssemblyTypes(servicesAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(coreAssembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
        }
    }
}