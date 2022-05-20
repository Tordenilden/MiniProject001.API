using Microsoft.EntityFrameworkCore;
using MiniProject001.DAL;
using MiniProject001.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.TEST
{
    /// <summary>
    /// Jeg tænker der er flere løsninger til det vi sidder og kigger på
    /// enten laver jeg opsætning inde i min startup fil
    /// 2) eller osse så koder jeg mig ud af problemerne ved at sætte det op her i min test hvilken server jeg benytter
    /// eller osse opsætning på klasse basis..
    /// </summary>
    public class AuthorRepositoryTest
    {
        private readonly DbContextOptions<AbContext> options;
        private readonly AbContext context;
        private readonly AuthorRepository repo;
        #region LØSNING 2
        //public AbContext DbContextOptions = new DbContextOptionsBuilder<AbContext>()
        //    .UseSqlServer().Options;
        //        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
        //    .Options;

        //using var context = new ApplicationDbContext(contextOptions);

        #endregion LØSNING 2

        #region //LØSNING 2
        //LØSNING 2)


        //        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
        //    .Options;

        //using var context = new ApplicationDbContext(contextOptions);

        #endregion //LØSNING 2
        public AuthorRepositoryTest()
        {
            //options = new DbContextOptionsBuilder<AbContext>()
            //    .UseInMemoryDatabase(databaseName:"TestH3").Options;
            //context = new(options); // pseudo opsætnig
            //repo = new(context);
        }

    }
}
