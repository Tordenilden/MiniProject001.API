using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL.Database.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public double wordCount { get; set; }
        public bool binding { get; set; }
        public DateTime releaseYear { get; set; }
        public int authorId { get; set; }
        public Author author { get; set; }//LINQ
    }
}
