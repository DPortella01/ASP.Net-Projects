namespace mvcShortTermRentals.Models
{
    public class PagedDTO<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }

        public List<T> Items { get; set; }


    }
}
