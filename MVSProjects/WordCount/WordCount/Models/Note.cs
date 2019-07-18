using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WordCount.Models
{
    public class Note
    {
        public int id { get; set;}

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Note")]
        [Required]
        public string text { get; set; }

        [Display(Name = "Word Count")]
        public int wordCount { get; set; }

        [Display(Name = "Last Updated")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }
}
