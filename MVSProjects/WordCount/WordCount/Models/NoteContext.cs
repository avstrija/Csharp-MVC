using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WordCount.Models
{
    public class WordCountContext : DbContext
    {
        public WordCountContext(DbContextOptions<WordCountContext> options)
            : base(options)
        {
        }

        public DbSet<WordCount.Models.Note> Note { get; set; }
    }
}
