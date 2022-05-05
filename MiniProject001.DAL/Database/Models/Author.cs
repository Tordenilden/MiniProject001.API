using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL.Database.Models
{
    public class Author
    {
        // EF - skal hedde id, ID, Id og/ eller classname+id
        public int AuthorId { get; set; } // PK
        public string name { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public bool isAlive { get; set; }
    }
}
