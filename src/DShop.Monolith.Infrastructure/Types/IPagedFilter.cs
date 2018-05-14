using System.Collections.Generic;

namespace DShop.Monolith.Infrastructure.Types
{
    public interface IPagedFilter<TResult, in TQuery> where TQuery : IQuery
    {
        PagedResult<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }
}