using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = "Joy" },
                new Subject { SubjectId = 2, SubjectName = "Funny" },
                new Subject { SubjectId = 3, SubjectName = "Coding" },
                new Subject { SubjectId = 4, SubjectName = "Despicable" },
                new Subject { SubjectId = 5, SubjectName = "Political" }
            );

            mb.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Spencer", LastName = "Hilton" },
                new Author { AuthorId = 2, FirstName = "Albert", LastName = "Einstein" },
                new Author { AuthorId = 3, FirstName = "J.K.", LastName = "Rowling" },
                new Author { AuthorId = 4, FirstName = "Russel", LastName = "Nelson" },
                new Author { AuthorId = 5, FirstName = "Elon", LastName = "Musk" },
                new Author { AuthorId = 6, FirstName = "Randall", LastName = "Munroe" },
                new Author { AuthorId = 7, FirstName = "Amulek" }
            );

            mb.Entity<Quote>().HasData(
                new Quote
                {
                    QuoteId = 1,
                    AuthorId = 1,
                    SubjectId = 2,
                    QuoteText = "CREATE TABLE Yeet",
                    Citation = "Heard it in 403 last semester",
                    Date = DateTime.Parse("Nov 7, 2021")
                },
                new Quote
                {
                    QuoteId = 2,
                    AuthorId = 6,
                    QuoteText = "I disagree strongly with whatever work this quote is attached to",
                    Citation = "https://xkcd.com/1942/",
                    Date = DateTime.Parse("2018-01-15"),
                },
                new Quote
                {
                    QuoteId = 3,
                    AuthorId = 7,
                    QuoteText = "Yea",
                    Citation = "Alma 11:33",
                }
            );

        }
    }
}
