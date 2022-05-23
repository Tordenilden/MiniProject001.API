using Microsoft.EntityFrameworkCore;
using MiniProject001.DAL.Database;
using MiniProject001.DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL
{
    //Why!! - polymorf, Unit test, og abstract tænkning
    public interface IAuthorRepository
    {
        Task<List<Author>> getAllAuthors();
        Task<List<Author>> getAllAuthorsAndBooks();
        Task<List<Author>> getAllAuthorsAndBooksDesc();
        Author getAuthor(int authorId);
        Task<int> createAuthor(Author author);
        Task<Author> deleteAuthor(int authorId);
        //void createAuthor(Author author);
    }
    /// <summary>
    /// OPGAVER:
    /// Prøv at query Author+(Book) : isAlive  true/false
    ///                             : age mellem 30 og 50
    /// Prøv at query Book+(Author) : title descending
    ///                             : releaseYear efter 2010 eks.
    /// 
    /// </summary>

    public class AuthorRepository : IAuthorRepository
    {
        #region       constructor
        private readonly AbContext context;
        public AuthorRepository()
        {

        }
        public AuthorRepository(AbContext context)
        {
            this.context = context;
        }
        #endregion       constructor
        #region       getAuthor
        public async Task<List<Author>> getAllAuthors() {
            return await context.Author.ToListAsync();
        }
 
        public Author getAuthor(int authorId)
        {
            return context.Author.FirstOrDefault((authorObj) => authorObj.AuthorId == authorId);
        }
        #endregion       getAuthor

        #region etellerandet navn lige her
        public async Task<int> createAuthor(Author author)
        {
            // burde jeg ikke tjekke om author findes i forvejen??
            var temp = context.Author.Add(author);
            int t = await context.SaveChangesAsync();
            return t;
        }
        //public void createAuthor(Author author)
        //{
        //    // burde jeg ikke tjekke om author findes i forvejen??
        //    var temp = context.Author.Add(author);
        //    int t =  context.SaveChanges();
        //    //return t;
        //}
        #endregion entity
        public async Task<Author> deleteAuthor(int authorId) {
            //authorExists = context.Author.FirstOrDefaultAsync(græsk)
            var authorExists = getAuthor(authorId);
            if (authorExists != null)
            {
                context.Author.Remove(authorExists);
                await context.SaveChangesAsync();
            }          
            return authorExists;
            //context.Author.Remove(hvilken author er det!!)
        }

        public async Task<List<Author>> getAllAuthorsAndBooks()
        {
            List<Author> list = new List<Author>();
            list = await context.Author.Include(author => author.Book).ToListAsync();
            return list;
        }

        public async Task<List<Author>> getAllAuthorsAndBooksDesc()
        {
            List<Author> list = new List<Author>();
            list = await context.Author.Include(author => author.Book)
                .OrderByDescending((a) => a.name).ToListAsync();
            return list;
        }
    }
}

#region       getMovie
#endregion    getMovie
#region    createMovie
#endregion createMovie
#region    deleteMovie
#endregion deleteMovie
#region    updateMovie
#endregion updateMovie