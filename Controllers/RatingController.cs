using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Areas.Identity.Data;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private RoleManager<IdentityRole>? roleManager;
        private UserManager<LibraryUser>? userManager;

        public RatingController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment,
            RoleManager<IdentityRole> roleManager,
            UserManager<LibraryUser> userManager)
        {
            _context = context;
          
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetRating(int bookId, decimal rank) 
        {
            Rating rating = new Rating();
            rating.Rank = rank;
            rating.BookID = bookId;
            rating.UserId = userManager.GetUserId(User);
            
            _context.Ratings.Add(rating);
            _context.SaveChanges();

          

           return RedirectToAction("Details", "Books", new { id = bookId });
        }

    }
}
