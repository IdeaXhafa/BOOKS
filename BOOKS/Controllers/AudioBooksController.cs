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
    public class AudioBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // public async Task<IActionResult> Index(){
        //     return View(await _context.Books.ToListAsync());
        // }
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

            var books = from s in _context.AudioBooks
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
            return View(await PaginatedList<AudioBooks>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.AudioBooks
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
            [Bind("Titulli,Autori,Listeners")] AudioBooks book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //book.E_Lire = true;
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

        // GET: Movies/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.AudioBooks.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Titulli,Autori,Listeners")] AudioBooks books)
        {
            if (id != books.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lib = _context.AudioBooks.FirstOrDefault(l => l.id == books.id);
                    lib.Titulli = books.Titulli;
                    lib.Autori = books.Autori;
                    lib.Listeners = books.Listeners;
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

            var l = await _context.AudioBooks
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
            var l = await _context.AudioBooks.FindAsync(id);
            _context.AudioBooks.Remove(l);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraExists(int id)
        {
            return _context.AudioBooks.Any(e => e.id == id);
        }

        public async Task<IActionResult> GetMostListeners(
                string sortOrder,
                string currentFilter,
                string searchString,
                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var books = from s in _context.AudioBooks
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
            return View(await PaginatedList<AudioBooks>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}