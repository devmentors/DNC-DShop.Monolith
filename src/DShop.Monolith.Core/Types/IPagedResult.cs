using System.Collections.Generic;

namespace DShop.Monolith.Core.Types
{
    public interface IPagedResult
    {
        int CurrentPage { get; }
        int ResultsPerPage { get; }
        int TotalPages { get; }
        long TotalResults { get; }
    }

    public interface IPagedResult<T> : IPagedResult
    {
        IEnumerable<T> Items { get; }
        bool IsEmpty { get; }
    }
}