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
    public class MagazinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MagazinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // public async Task<IActionResult> Index(){
        //     return View(await _context.Magazines.ToListAsync());
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

            var books = from s in _context.Magazines
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
                books = books.Where(s => s.name.Contains(searchString) || s.company.Contains(searchString) || s.description.Contains(searchString));
            }

            int pageSize = 20;
            return View(await PaginatedList<Magazines>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Magazines
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
            [Bind("name,company,description")] Magazines magazine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(magazine);
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
            return View(magazine);
        }

        // GET: Movies/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Magazines.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,company,description")] Magazines magazine)
        {
            if (id != magazine.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lib = _context.Magazines.FirstOrDefault(l => l.id == magazine.id);
                    lib.name = magazine.name;
                    lib.company = magazine.company;
                    lib.description = magazine.description;
                    _context.Update(lib);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraExists(magazine.id))
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
            return View(magazine);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var l = await _context.Magazines
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
            var l = await _context.Magazines.FindAsync(id);
            _context.Magazines.Remove(l);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraExists(int id)
        {
            return _context.Magazines.Any(e => e.id == id);
        }
    }
}
