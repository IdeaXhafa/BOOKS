using BOOKS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BOOKS.Areas.Identity.Data;
using BOOKS.Models;

namespace BOOKS.Controllers
{
    public class BestSellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BestSellersController(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<IActionResult> Index(
                string sortOrder,
                string currentFilter,
                string searchString,
                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var books = from s in _context.BestSeller
                         select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Titulli.Contains(searchString) || s.Autori.Contains(searchString));
            }

            int pageSize = 20;
            return View(await PaginatedList<BestSeller>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.BestSeller
                .FirstOrDefaultAsync(m => m.id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Titulli,Autori,Rating,Year")] BestSeller book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(book);

        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.BestSeller.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Titulli,Autori,Rating,Year")] BestSeller books)
        {
            if (id != books.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lib = _context.BestSeller.FirstOrDefault(l => l.id == books.id);
                    lib.Titulli = books.Titulli;
                    lib.Autori = books.Autori;
                    lib.Rating = books.Rating;
                    lib.Year = books.Year;
                    _context.Update(lib);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraExists(books.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(books);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var l = await _context.BestSeller
                .FirstOrDefaultAsync(m => m.id == id);
            if (l == null)
            {
                return NotFound();
            }

            return View(l);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var l = await _context.BestSeller.FindAsync(id);
            _context.BestSeller.Remove(l);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraExists(int id)
        {
            return _context.BestSeller.Any(e => e.id == id);
        }

        public async Task<IActionResult> GetRatings(
                string sortOrder,
                string currentFilter,
                string searchString,
                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var books = from s in _context.BestSeller
                         select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Titulli.Contains(searchString) || s.Autori.Contains(searchString));
            }

            int pageSize = 20;
            return View(await PaginatedList<BestSeller>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}