using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
            new Book { BookID = 1, AuthorID = 03, Title = "Две сестри", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Есе", ReleaseDate = DateTime.Parse("2022-05-02"), FilePath = "file1.docx" },
            new Book { BookID = 2, AuthorID = 02, Title = "Чужденецът", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Разказ", ReleaseDate = DateTime.Parse("2022-01-01"), FilePath = "file2.docx" },
            new Book { BookID = 3, AuthorID = 01, Title = "Суша", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Разказ", ReleaseDate = DateTime.Parse("2022-02-01"), FilePath = "file3.docx" },
            new Book { BookID = 4, AuthorID = 04, Title = "Безславни дни", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Разказ", ReleaseDate = DateTime.Parse("2022-02-11"), FilePath = "file4.docx" },
            new Book { BookID = 5, AuthorID = 02, Title = "Призрачния кораб", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Новела", ReleaseDate = DateTime.Parse("2022-03-11"), FilePath = "file5.docx" },
            new Book { BookID = 3, AuthorID = 04, Title = "Мъртви цветя", Snippet = "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre = "Стихотворение", ReleaseDate = DateTime.Parse("2022-03-06"), FilePath = "file6.docx" }
                );
        }
    }
}
