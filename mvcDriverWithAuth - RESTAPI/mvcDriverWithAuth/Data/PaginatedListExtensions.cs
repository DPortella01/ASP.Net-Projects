using Microsoft.EntityFrameworkCore;
using mvcShortTermRentals.Models;

namespace mvcShortTermRentals.Data
{
    public static class PaginatedListExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            var itemsToSkip = (pageIndex - 1) * pageSize;

            var count = await query.CountAsync();
            var items = await query.Skip(itemsToSkip).Take(pageSize).ToListAsync(); // skip helps to determine where to start, take how many to return from there

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static async Task<PagedDTO<T>> ToPagedDTOAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            var itemsToSkip = (pageIndex - 1) * pageSize;

            var count = await query.CountAsync();
            var items = await query.Skip(itemsToSkip).Take(pageSize).ToListAsync(); // skip helps to determine where to start, take how many to return from there

            var dto = new PagedDTO<T>()
            {
                // initialize the properties
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemCount = count,
                Items = items
            };

            return dto;
        }
    }
}
