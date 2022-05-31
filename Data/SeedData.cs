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
            new Author{OwnerID="1018ef39-af4c-4783-8a5a-9a7bfcb680f3", FullName="Иван Иванов",Department="Славянска филология",Grade=1, Email="carson@lib.not", Phone="088776655"},
             new Author{OwnerID="6948c4ec-df1f-42d8-8fc1-d694a409a667", FullName="Петко Александров",Department="Славянска филология",Grade=4, Email="ptko@lib.not", Phone="088445533"},
             new Author{OwnerID="53ab0bf0-f61d-4ca6-a9a6-fc90e1b65efb", FullName="Мая Александрова",Department="Класическа филология",Grade=4, Email="maja@lib.not", Phone="0788945533"},
             new Author{OwnerID="8287823e-b95d-4ce1-beb7-d4164cc9b7fc", FullName="Ивана Илиева",Department="Английска филология", Grade=2, Email="ivana@lib.not", Phone="098495593"},
             new Author{OwnerID="6aed1bc7-33a9-4e87-b1e7-b44e5c0ba9b5", FullName="Стоян Михайлов",Department="Славянска филология",Grade=3, Email="stojan@lib.not", Phone="0778475533"},
             new Author{OwnerID="316fb89e-2495-41b7-bb04-f184383a6123", FullName="Димитър Петков",Department="Филолософски факултет",Grade=2, Email="dim@lib.not", Phone="0994655433"}

                };
                    foreach (Author s in authors)
                    {
                        context.Authors.Add(s);
                    }
                    context.SaveChanges();

                    var books = new Book[]
                    {
            new Book{AuthorID=authors.Single(i => i.FullName=="Иван Иванов").AuthorId, Title="Две сестри", Snippet="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consequat, sem ut feugiat sodales, nulla elit blandit purus, efficitur vulputate augue nibh ut urna. Phasellus tellus massa, aliquet nec urna non, semper feugiat nulla. Integer pretium erat quis justo tempus viverra. Fusce lorem dolor, tincidunt feugiat mi quis, faucibus gravida dui. Pellentesque et lectus at odio commodo dictum. In non risus pharetra, tempus quam eu, condimentum ex. Donec tincidunt nibh vel rutrum sollicitudin. Donec a orci augue. Aliquam erat volutpat....", Ganre="Есе", ReleaseDate=DateTime.Parse("2022-05-02"), FilePath="file1.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Петко Александров").AuthorId, Title="Чужденецът", Snippet="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consequat, sem ut feugiat sodales, nulla elit blandit purus, efficitur vulputate augue nibh ut urna. Phasellus tellus massa, aliquet nec urna non, semper feugiat nulla. Integer pretium erat quis justo tempus viverra. Fusce lorem dolor, tincidunt feugiat mi quis, faucibus gravida dui. Pellentesque et lectus at odio commodo dictum. In non risus pharetra, tempus quam eu, condimentum ex. Donec tincidunt nibh vel rutrum sollicitudin. Donec a orci augue. Aliquam erat volutpat....", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-01-01"), FilePath="file2.docx" },
            new Book{AuthorID=authors.Single(i => i.FullName=="Петко Александров").AuthorId, Title="Суша", Snippet="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consequat, sem ut feugiat sodales, nulla elit blandit purus, efficitur vulputate augue nibh ut urna. Phasellus tellus massa, aliquet nec urna non, semper feugiat nulla. Integer pretium erat quis justo tempus viverra. Fusce lorem dolor, tincidunt feugiat mi quis, faucibus gravida dui. Pellentesque et lectus at odio commodo dictum. In non risus pharetra, tempus quam eu, condimentum ex. Donec tincidunt nibh vel rutrum sollicitudin. Donec a orci augue. Aliquam erat volutpat....", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-02-01"), FilePath="file3.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Ивана Илиева").AuthorId, Title="Безславни дни",Snippet="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consequat, sem ut feugiat sodales, nulla elit blandit purus, efficitur vulputate augue nibh ut urna. Phasellus tellus massa, aliquet nec urna non, semper feugiat nulla. Integer pretium erat quis justo tempus viverra. Fusce lorem dolor, tincidunt feugiat mi quis, faucibus gravida dui. Pellentesque et lectus at odio commodo dictum. In non risus pharetra, tempus quam eu, condimentum ex. Donec tincidunt nibh vel rutrum sollicitudin. Donec a orci augue. Aliquam erat volutpat....", Ganre="Разказ", ReleaseDate=DateTime.Parse("2022-02-11"), FilePath="file4.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Иван Иванов").AuthorId, Title="Призрачния кораб", Snippet="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consequat, sem ut feugiat sodales, nulla elit blandit purus, efficitur vulputate augue nibh ut urna. Phasellus tellus massa, aliquet nec urna non, semper feugiat nulla. Integer pretium erat quis justo tempus viverra. Fusce lorem dolor, tincidunt feugiat mi quis, faucibus gravida dui. Pellentesque et lectus at odio commodo dictum. In non risus pharetra, tempus quam eu, condimentum ex. Donec tincidunt nibh vel rutrum sollicitudin. Donec a orci augue. Aliquam erat volutpat....", Ganre="Новела", ReleaseDate=DateTime.Parse("2022-03-11"), FilePath="file5.docx"},
            new Book{AuthorID=authors.Single(i => i.FullName=="Димитър Петков").AuthorId, Title="Мъртви цветя", Snippet="Как живите цветя ухаят с красив и чувствен аромат...Не ги откъсвай от душата - без време ще се изсушат.", Ganre="Стихотворение", ReleaseDate=DateTime.Parse("2022-03-06"), FilePath="file6.docx"}

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