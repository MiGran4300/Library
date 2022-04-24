using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Library.Models;

namespace Library.Data
{
    
        public class SeedData
        {
        public class DbInitializer
        {
            private readonly ApplicationDbContext context;
            public DbInitializer(ApplicationDbContext context)
            {
                this.context = context;
            }


            public void Initialize()
            {
                // context.Database.EnsureCreated();

                // Look for any students.
                if (context.Authors.Any())
                {
                    return;   // DB has been seeded
                }

                else
                {


                    var authors = new Author[]
                {
            new Author{ FullName="Иван Иванов",Department="Славянска филология", Email="carson@lib.not", Phone=088776655},
             new Author{ FullName="Петко Александров",Department="Славянска филология", Email="ptko@lib.not", Phone=088445533},
             new Author{FullName="Мая Александрова",Department="Българска филология", Email="maja@lib.not", Phone=0788945533},
             new Author{FullName="Ивана Илиева",Department="Английска филология", Email="ivana@lib.not", Phone=098495593},
             new Author{FullName="Стоян Михайлов",Department="Славянска филология", Email="stojan@lib.not", Phone=0778475533},
             new Author{FullName="Димитър Петков",Department="Китайска филология", Email="dim@lib.not", Phone=099465543}

                };
                    foreach (Author s in authors)
                    {
                        context.Authors.Add(s);
                    }
                    context.SaveChanges();

                    var books = new Book[]
                    {
            new Book{AuthorID=authors.Single(i => i.FullName=="Иван Иванов").AuthorId, Title="Две сестри", Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Есе", ReleaseDate=DateTime.Parse("2022-05-02"), FilePath="file1.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Петко Александров").AuthorId, Title="Чужденецът", Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-01-01"), FilePath="file2.docx" },
            new Book{AuthorID=authors.Single(i => i.FullName=="Петко Александров").AuthorId, Title="Суша", Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-02-01"), FilePath="file3.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Ивана Илиева").AuthorId, Title="Безславни дни",Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-02-11"), FilePath="file4.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Иван Иванов").AuthorId, Title="Призрачния кораб", Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Новела", ReleaseDate=DateTime.Parse("2022-03-11"), FilePath="file5.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Димитър Петков").AuthorId, Title="Мъртви цветя", Snippet="Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", Ganre="Стихотворение", ReleaseDate=DateTime.Parse("2022-03-06"), FilePath="file6.docx"}

                    };
                    foreach (Book c in books)
                    {
                        context.Books.Add(c);
                    }
                    context.SaveChanges();
                }
            }
        }    
    }
}