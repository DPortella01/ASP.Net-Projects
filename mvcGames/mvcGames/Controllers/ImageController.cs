using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcGames.Data;

namespace mvcGames.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var image = await _context.Files.FindAsync(id);

            //Making sure image is valid
            if (image != null
                && image.Content != null
                && image.ContentType != null)
            {
                return File(image.Content, image.ContentType);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileModel = await _context.Files.FirstOrDefaultAsync(f => f.Id == id);

            if (fileModel == null)
            {
                return NotFound();
            }

            return File(fileModel.Content, fileModel.ContentType);
        }
    }
}
