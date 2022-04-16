using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuoteApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuoteRepository _repo;

        public HomeController(ILogger<HomeController> logger, IQuoteRepository repo)
        {
            _logger = logger;
            _repo = repo;

        }

        public IActionResult Index()
        {
            List<Quote> quotes = _repo.Quotes
                .Include(q => q.Author)
                .Include(q => q.Subject)
                .OrderBy(q => q.Author.LastName)
                .ThenBy(q => q.Author.FirstName)
                .ToList<Quote>();
            return View(quotes);
        }

        public IActionResult QuoteDetails(int id)
        {
            Quote quote = _repo.Quotes
                .Include(q => q.Subject)
                .Include(q => q.Author)
                .FirstOrDefault(q => q.QuoteId == id);
            return View(quote);
        }

        [HttpGet]
        public IActionResult AddQuote()
        {
            ViewBag.Subjects = _repo.Subjects.ToList<Subject>();
            ViewBag.Authors = _repo.Authors.ToList<Author>();
            ViewBag.EditMode = false;
            return View("QuoteForm");
        }

        [HttpPost]
        public IActionResult AddQuote(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _repo.AddQuote(quote);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Subjects = _repo.Subjects.ToList<Subject>();
                ViewBag.Authors = _repo.Authors.ToList<Author>();
                ViewBag.EditMode = false;
                return View("QuoteForm", quote);
            }
        }

        [HttpGet]
        public IActionResult EditQuote(int id)
        {
            Quote quote = _repo.Quotes
            .FirstOrDefault(q => q.QuoteId == id);

            ViewBag.Subjects = _repo.Subjects.ToList<Subject>();
            ViewBag.Authors = _repo.Authors.ToList<Author>();
            ViewBag.EditMode = true;

            return View("QuoteForm", quote);
        }

        [HttpPost]
        public IActionResult EditQuote(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateQuote(quote);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Subjects = _repo.Subjects.ToList<Subject>();
                ViewBag.Authors = _repo.Authors.ToList<Author>();
                ViewBag.EditMode = true;
                return View("QuoteForm", quote);
            }
        }

        [HttpGet]
        public IActionResult DeleteQuote(int id)
        {
            Quote quote = _repo.Quotes
                .Include(quote => quote.Author)
                .FirstOrDefault(q => q.QuoteId == id);
            return View("QuoteDelete", quote);
        }

        [HttpPost]
        public IActionResult DeleteQuote(Quote quote)
        {
            _repo.RemoveQuote(quote);
            return RedirectToAction("Index");
        }

        public IActionResult RandomQuote()
        {
            List<Quote> quotes = _repo.Quotes.ToList<Quote>();
            // select random quote
            var random = new Random();
            int randomIndex = random.Next(quotes.Count);
            Quote randomQuote = quotes[randomIndex];

            return RedirectToAction("QuoteDetails", new { id = randomQuote.QuoteId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
