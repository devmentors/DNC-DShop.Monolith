using System.Threading.Tasks;

namespace DShop.Monolith.Core.Types
{
    public interface IAsyncSpecification<in T>
    {
        Task<bool> IsSatisfiedByAsync(T value);
    }
}