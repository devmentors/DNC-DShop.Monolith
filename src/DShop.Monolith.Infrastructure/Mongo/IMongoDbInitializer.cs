using System.Threading.Tasks;

namespace DShop.Monolith.Infrastructure.Mongo
{
    public interface IMongoDbInitializer
    {
        Task InitializeAsync();
    }
}