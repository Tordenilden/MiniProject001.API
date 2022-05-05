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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TEC-5350-LA0052;Database=OnsdagAften; Trusted_Connection=True");
        }
        public DbSet<Author> Author { get; set; }
    }
}
