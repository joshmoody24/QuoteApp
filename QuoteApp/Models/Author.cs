using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        // needs to be optional for our boy Amulek
        public string? LastName { get; set; }
    }
}
