using System.Collections.Generic;
using System.Linq;
using DShop.Monolith.Core.Types;

namespace DShop.Monolith.Infrastructure.Types
{
    public class PagedResult<T> : PagedResultBase, IPagedResult<T>
    {
        public IEnumerable<T> Items { get; private set; } = Enumerable.Empty<T>();
        public bool IsEmpty => !Items.Any();

        protected PagedResult()
        {
        }

        protected PagedResult(IEnumerable<T> items,
            int currentPage, int resultsPerPage,
            int totalPages, long totalResults) :
                base(currentPage, resultsPerPage, totalPages, totalResults)
        {
            Items = items;
        }

        public static PagedResult<T> Create(IEnumerable<T> items,
            int currentPage, int resultsPerPage,
            int totalPages, long totalResults)
            => new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults);

        public static PagedResult<T> From(PagedResultBase result, IEnumerable<T> items)
            => new PagedResult<T>(items, result.CurrentPage, result.ResultsPerPage,
                result.TotalPages, result.TotalResults);

        public static PagedResult<T> Empty => new PagedResult<T>();
    }
}