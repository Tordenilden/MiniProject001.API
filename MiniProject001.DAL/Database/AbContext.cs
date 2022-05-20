using Microsoft.EntityFrameworkCore;
using MiniProject001.DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL.Database
{
    // alt databasehejs
    public class AbContext :DbContext
    {
        public AbContext() { } // når vi skal teste vores repo...
        public AbContext(DbContextOptions<AbContext> flemse) : base(flemse) { }
        public DbContextOptions<AbContext> test { get; set; }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
//} // når vi skal teste vores repo...
//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    test
//    if(test == null)
//    {
//        optionsBuilder.UseSqlServer(@"Server=TEC-5350-LA0052;Database=OnsdagAften; Trusted_Connection=True");
//    }

//}