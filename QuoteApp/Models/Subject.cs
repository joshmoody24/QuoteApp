using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }
    }
}
