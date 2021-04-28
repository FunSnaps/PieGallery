using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PieGallery.Data;
using PieGallery.Models;

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
            return View(await _context.Comics.ToListAsync());
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
                return View("Index", await _context.Comics.Where(comic => comic.Author.Contains(SearchAuthor)).ToListAsync());
            }
            else
            {
                return View("Index", await _context.Comics.Where(comic => comic.Publisher.Contains(SearchPublisher)).ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comics == null)
            {
                return NotFound();
            }

            return View(comics);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Publisher,ReleaseDate,Streamed,Image,AgeRating,Price")] Comics comics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comics);
        }

        [HttpGet]
        [Authorize]
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
            return View(comics);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Publisher,ReleaseDate,Streamed,Image,AgeRating,Price")] Comics comics)
        {
            if (id != comics.Id)
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
                    if (!ComicsExists(comics.Id))
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
            return View(comics);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comics = await _context.Comics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comics == null)
            {
                return NotFound();
            }

            return View(comics);
        }

        [Authorize]
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
            return _context.Comics.Any(e => e.Id == id);
        }
    }
}
