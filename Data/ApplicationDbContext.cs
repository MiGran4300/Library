using Library.Areas.Identity.Data;
using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : IdentityDbContext<LibraryUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Costumer>? Costumers { get; set; }
        public DbSet<Rent>? Rents { get; set; }
        public DbSet<Book>? Books { get; set; }
    }
}