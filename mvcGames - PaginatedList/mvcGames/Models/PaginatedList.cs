namespace mvcGames.Models
{
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Current Page Index
        /// </summary>
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize) 
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (decimal)pageSize); //Ceiling to round up, casting to get correct overload

            AddRange(items);
        }

        public int PreviousPageIndex
        {
            get
            {
                return PageIndex - 1;
            }
        }

        public int NextPageIndex
        {
            get
            {
                return PageIndex + 1;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public string? SearchFilter { get; set; }
    }
}
