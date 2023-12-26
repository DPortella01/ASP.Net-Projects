using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcGames.Models
{
    public static class SelectListExtensions
    {
        public static SelectList GetSelectList(this IEnumerable<Platform>? platforms, int? selectedValue = null)
        {
            return new SelectList(platforms, "Id", "Name", selectedValue);
        }
    }
}