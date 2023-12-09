using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooKStore.Repository;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly DatabaseContext _context;

        public BooksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(int? genre,int? author)
        {
            var query = _context.Book.AsQueryable();

            // Combine conditions using && (logical AND) operator
            query = query.Where(v =>
                (!genre.HasValue || v.GenreId == genre.Value) &&
                (!author.HasValue || v.AuthorId == author.Value))
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.Status);

            var result = await query.ToListAsync();
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "AuthorName");
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name");
            return View(result);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "AuthorName");
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "PublisherName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TotalPages,AuthorId,PublisherId,GenreId,StatusId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "AuthorName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "PublisherName", book.PublisherId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name",book.GenreId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "AuthorName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "PublisherName", book.PublisherId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", book.StatusId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,TotalPages,AuthorId,PublisherId,GenreId,StatusId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "AuthorName", book.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", book.GenreId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "PublisherName", book.PublisherId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", book.StatusId);
            return View(book);
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'DatabaseContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
