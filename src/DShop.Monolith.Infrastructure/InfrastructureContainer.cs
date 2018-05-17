using System.Reflection;
using Autofac;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Domain.Customers;
using DShop.Monolith.Core.Domain.Identity;
using DShop.Monolith.Core.Domain.Orders;
using DShop.Monolith.Core.Domain.Products;
using DShop.Monolith.Infrastructure.Mongo;
using Product = DShop.Monolith.Core.Domain.Products.Product;

namespace DShop.Monolith.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();  
            builder.AddMongoDB();
            builder.AddMongoDBRepository<Cart>("Carts");
            builder.AddMongoDBRepository<Customer>("Customers");
            builder.AddMongoDBRepository<Order>("Orders");
            builder.AddMongoDBRepository<Product>("Products");
            builder.AddMongoDBRepository<RefreshToken>("RefreshTokens");
            builder.AddMongoDBRepository<User>("Users");
        }        
    }
}