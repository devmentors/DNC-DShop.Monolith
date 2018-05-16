using System.Reflection;
using Autofac;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DShop.Monolith.Services
{
    public static class ServicesContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
        }
    }
}