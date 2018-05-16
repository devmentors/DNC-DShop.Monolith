
namespace DShop.Monolith.Core.Types
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T value);
    }
}