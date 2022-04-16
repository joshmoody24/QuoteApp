using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private QuoteDbContext _context { get; set; }
        public EFQuoteRepository(QuoteDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Quote> Quotes => _context.Quotes;

        public IQueryable<Author> Authors => _context.Authors;

        public IQueryable<Subject> Subjects => _context.Subjects;

        public void AddQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void RemoveQuote(Quote quote)
        {
            _context.Quotes.Remove(quote);
            _context.SaveChanges();
        }

        public void UpdateQuote(Quote quote)
        {
            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }
    }
}
