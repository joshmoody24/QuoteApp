using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }
        IQueryable<Author> Authors { get; }
        IQueryable<Subject> Subjects { get; }

        public void AddQuote(Quote quote);
        public void RemoveQuote(Quote quote);
        public void UpdateQuote(Quote quote);

    }
}
