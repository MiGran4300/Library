﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Library.Areas.Identity.Data;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{[Authorize (Roles="Admin")]
    public class Admin : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<LibraryUser> userManager;

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public Admin(ApplicationDbContext context, IWebHostEnvironment hostEnvironment,
            RoleManager<IdentityRole> roleManager,
            UserManager<LibraryUser> userManager)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // GET: Books
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {


            ViewData["CurrentSort"] = sortOrder;

            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
            ViewData["ReleaseDateSortParm"] = sortOrder == "ReleaseDate" ? "ReleaseDate desc" : "ReleaseDate";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;

            }
            ViewData["CurrentFilter"] = searchString;



            var book = from s in _context.Books.Include(c => c.Authors)
                       where s.Status != Book.ContactStatus.Approved
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                book = book.Where(s => s.Authors.FullName.Contains(searchString));

            }

            switch (sortOrder)
            {

                case "Title":
                    book = book.OrderByDescending(s => s.Title);
                    break;
                case "ReleaseDate desc":
                    book = book.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "ReleaseDate":
                    book = book.OrderBy(s => s.ReleaseDate);
                    break;
                default:
                    book = book.OrderByDescending(s => s.ReleaseDate);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Book>.CreateAsync(book.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorId", "FullName", book.AuthorID);
            return View(book);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,AuthorID, Title,Ganre,Snippet,ReleaseDate,Status,File")] Book book)
        {
            if (id != book.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid && book.File != null)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(book.File.FileName);
                    string extension = Path.GetExtension(book.File.FileName);
                    book.FilePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/upload/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await book.File.CopyToAsync(fileStream);
                    }
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookID))
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
            else
            {
            book.FilePath = "file.doc";
            
                _context.Update(book);
                await _context.SaveChangesAsync();
                ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorId", "FullName", book.AuthorID);
                
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = await _context.Books.FindAsync(id);
            var book = _context.Books.OrderBy(e => e.Title).Include(e => e.Ratings).First();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }


        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename is not availble");
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string path = Path.Combine(wwwRootPath + "/upload/", filename);


            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        // Get content type
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        // Get mime types
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
    {
        {".txt", "text/plain"},
        {".pdf", "application/pdf"},
        {".doc", "application/vnd.ms-word"},
        {".docx", "application/vnd.ms-word"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".png", "image/png"},
        {".jpg", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".gif", "image/gif"},
        {".csv", "text/csv"}
    };
        }

    }
}