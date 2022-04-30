#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Library.Areas.Identity.Data;

namespace Library.Controllers
{
    public class AuthorsController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<LibraryUser> userManager;

        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
            UserManager<LibraryUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: 
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fullname_desc" : "";
            ViewData["DepartmentSortParm"] = sortOrder == "Department" ? "department_desc" : "Department";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var author = from s in _context.Authors 
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                author = author.Where(s => s.FullName.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "fullname_desc":
                    author = author.OrderByDescending(s => s.FullName);
                    break;
                case "Department":
                    author = author.OrderBy(s => s.Department);
                    break;
                case "department_desc":
                    author = author.OrderByDescending(s => s.Department);
                    break;
                default:
                    author = author.OrderBy(s => s.FullName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Author>.CreateAsync(author.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Costumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                   .Include(s => s.Books)
                    .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AuthorId == id);
         
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        
        // GET: Costumers/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Costumers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,FullName,Department, Grade, Email, Phone")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        [Authorize]
        // GET: Costumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        
        // POST: Costumers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FullName,Department, Grade, Email, Phone")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostumerExists(author.AuthorId))
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
            return View(author);
        }
        [Authorize]
        // GET: Costumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        
        // POST: Costumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = await _context.Authors.FindAsync(id);
            var author = _context.Authors.OrderBy(e => e.FullName).Include(e => e.Books).First();
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostumerExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
