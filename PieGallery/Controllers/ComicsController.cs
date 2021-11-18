using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PieGallery.Data;
using PieGallery.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PieGallery.Controllers
{
    public class ComicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comics.Include(c => c.Authors).Include(c => c.Publisher);
            return View(await applicationDbContext.ToListAsync());

        }

        [HttpGet]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowSearchResults(String SearchTitle, String SearchAuthor, String SearchPublisher)
        {
            if (SearchTitle != null)
            {
                return View("Index", await _context.Comics.Where(comic => comic.Title.Contains(SearchTitle)).ToListAsync());
            }
            else if (SearchAuthor != null)
            {
                return View("Index", await _context.Comics.Where(comic => comic.Authors.Name.Contains(SearchAuthor)).ToListAsync());
            }
            else
            {
                return View("Index", await _context.Comics.Where(comic => comic.Publisher.Name.Contains(SearchPublisher)).ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comics = await _context.Comics
                .Include(c => c.Authors)
                .Include(c => c.Publisher)
                .FirstOrDefaultAsync(m => m.id == id);

            if (comics == null)
            {
                return NotFound();
            }

            return View(comics);
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Set<Authors>(), "id", "id");
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "id", "id");
            return View();
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,AuthorId,PublisherId,ReleaseDate,ComicImage,AgeRating,Price")] Comics comic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Authors>(), "id", "id");
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "id", "id");
            return View(comic);
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin, Member")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comics = await _context.Comics.FindAsync(id);
            if (comics == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Authors>(), "id", "id");
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "id", "id");
            return View(comics);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin,Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,AuthorId,PublisherId,ReleaseDate,ComicImage,AgeRating,Price")] Comics comics)
        {
            if (id != comics.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicsExists(comics.id))
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
            ViewData["AuthorId"] = new SelectList(_context.Set<Authors>(), "id", "id");
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "id", "id");
            return View(comics);
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comics = await _context.Comics
                .Include(c => c.Authors)
                .Include(c => c.Publisher)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comics == null)
            {
                return NotFound();
            }

            return View(comics);
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comics = await _context.Comics.FindAsync(id);
            _context.Comics.Remove(comics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicsExists(int id)
        {
            return _context.Comics.Any(e => e.id == id);
        }
    }
}
