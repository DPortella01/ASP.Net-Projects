using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace mvcDriverWithAuth.Models
{
    public static class SelectListExtensions
    {
        public static SelectList GetSelectList(this IEnumerable<Make>? makes, int? selectedValue = null)
        {
            return new SelectList(makes, "Id", "MakeName", selectedValue);
        }
    }
}
