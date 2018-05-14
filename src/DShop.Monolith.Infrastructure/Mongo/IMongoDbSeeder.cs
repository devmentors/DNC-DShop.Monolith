using System.Threading.Tasks;

namespace DShop.Monolith.Infrastructure.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}