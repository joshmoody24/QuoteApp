using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public class Quote
    {
        [Required]
        [Key]
        public int QuoteId { get; set; }

        [Required(ErrorMessage = "Quote Text is required")]
        public string QuoteText { get; set; }


        [Required(ErrorMessage = "Please select an author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public DateTime? Date { get; set; }
        
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public string? Citation { get; set; }

    }
}
