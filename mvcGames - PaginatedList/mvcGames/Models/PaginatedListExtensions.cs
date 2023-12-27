using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace mvcGames.Models
{
    public static class PaginatedListExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        { 
            var itemsToSkip = (pageIndex - 1) * pageSize;

            var count = await query.CountAsync();
            var items = await query.Skip(itemsToSkip).Take(pageSize).ToListAsync(); //skip helps to determine where to start, take how many to return from
        
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
