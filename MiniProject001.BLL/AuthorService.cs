using MiniProject001.DAL;
using MiniProject001.DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.BLL
{
    /// <summary>
    /// 1) Create the class model+service  (AuthorService)
    /// 2) Create the interface for the class (IAuthorService)
    /// 3) Add reference to DAL project
    /// 4) Add methods to interface and implement in the class (AuthorService)
    /// 5) Controller - Add reference to BLL layer (AuthorBLLController)
    /// 6) DI in the Controller (AuthorBLLController)
    /// 7) startup.cs => services.AddScoped<IAuthorService, AuthorService>();
    /// 8) IN THIS LAYER DATA TRANSFORMATION IS AND ANY CALCULATIONS
    /// </summary>
    /// 

    public interface IAuthorService
    {
        Task<List<Author>> getAllAuthors();
    }
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository context;
        public AuthorService(IAuthorRepository c)
        {
            context = c;
        }
        // Jætte kedeligt...
        public async Task<List<Author>> getAllAuthors()
        {
            return await context.getAllAuthors();
        }
    }
}
