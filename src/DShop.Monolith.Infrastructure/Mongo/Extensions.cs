using Autofac;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DShop.Monolith.Infrastructure.Mongo
{
    public static class Extensions
    {
        public static void AddMongoDB(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MongoDbOptions>("mongo");
                return options;

            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                return new MongoClient(options.ConnectionString);

            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                var client = context.Resolve<MongoClient>();
                return client.GetDatabase(options.Database);

            }).InstancePerLifetimeScope();

            builder.RegisterType<MongoDbInitializer>()
                .As<IMongoDbInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MongoDbSeeder>()
                .As<IMongoDbSeeder>()
                .InstancePerLifetimeScope();
        }

        public static void AddMongoDBRepository<TEntity>(this ContainerBuilder builder, string collectionName) 
            where TEntity : IEntity
            => builder.Register(ctx => new MongoRepository<TEntity>(ctx.Resolve<IMongoDatabase>(), collectionName))
                .As<IMongoRepository<TEntity>>()
                .InstancePerLifetimeScope();
    }
}