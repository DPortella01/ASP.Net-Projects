using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcGames.Data;
using mvcGames.Models;

namespace mvcGames.Controllers
{
    [Authorize]
    public class VideoGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private const int DEFAULT_INDEX = 1;
        private const int DEFAULT_PAGE_SIZE = 4;

        public VideoGamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: VideoGames
        public async Task<IActionResult> Index(string? searchFilter, string? resetSearch, int pageIndex = DEFAULT_INDEX, int pageSize = DEFAULT_PAGE_SIZE)
        {
            if (resetSearch == "Reset")
            {
                searchFilter = string.Empty;
            }

            var query = _context.VideoGames.AsQueryable();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                query = query.Where(p => p.Title.Contains(searchFilter));
            }

            var videoGame = await query.ToPaginatedListAsync(pageIndex, pageSize);

            videoGame.SearchFilter = searchFilter;

            return View(videoGame);
        }

        [AllowAnonymous]
        // GET: VideoGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoGames == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGames
                //.Include(v => v.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                videoGame.ShowModifyLinks = true;
            }

            return View(videoGame);
        }

        [Authorize]
        // GET: VideoGames/Create
        public IActionResult Create()
        {
            var model = new VideoGame();
            LoadPlatforms(model);
            return View(model);
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ReleaseYear,PersonalRating,PlatformId")] VideoGame videoGame, IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null && imageUpload.Length > 0)
                {
                    videoGame.Image = await imageUpload.ConvertToFileModelAsync();
                }


                _context.Add(videoGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LoadPlatforms(videoGame, videoGame.PlatformId);
            return View(videoGame);
        }

        [Authorize]
        // GET: VideoGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VideoGames == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                videoGame.ShowModifyLinks = true;
            }

            LoadPlatforms(videoGame, videoGame.PlatformId);
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ReleaseYear,PersonalRating,PlatformId")] VideoGame videoGame, IFormFile imageUpload)

        {
            if (id != videoGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageUpload != null && imageUpload.Length > 0)
                    {
                        videoGame.Image = await imageUpload.ConvertToFileModelAsync();
                    }

                    _context.Update(videoGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameExists(videoGame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            LoadPlatforms(videoGame, videoGame.PlatformId);
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoGames == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGames
                .Include(v => v.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoGames == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VideoGames'  is null.");
            }
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame != null)
            {
                _context.VideoGames.Remove(videoGame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGameExists(int id)
        {
          return (_context.VideoGames?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private void LoadPlatforms(VideoGame? model = null, int? platformId = null)
        {
            if (model != null)
            {
                model.AvailablePlatforms = _context.Platforms.GetSelectList();
            }
        }
    }
}
