namespace DShop.Monolith.Core.Types
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; private set; }
        public int ResultsPerPage { get; private set; }
        public int TotalPages { get; private set; }
        public long TotalResults { get; private set; }

        protected PagedResultBase()
        {
        }

        protected PagedResultBase(int currentPage, int resultsPerPage,
            int totalPages, long totalResults)
        {
            CurrentPage = currentPage > totalPages ? totalPages : currentPage;
            ResultsPerPage = resultsPerPage;
            TotalPages = totalPages;
            TotalResults = totalResults;
        }
    }
}