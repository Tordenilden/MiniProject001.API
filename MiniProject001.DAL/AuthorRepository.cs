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
        Author getAuthor(int authorId);
        void createAuthor(Author author);
        void delete(int authorId);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly AbContext context;

        public AuthorRepository(AbContext context)
        {
            this.context = context;
        }

        public async Task<List<Author>> getAllAuthors() {
            return await context.Author.ToListAsync();
        }
 
        public Author getAuthor(int authorId)
        {
            return context.Author.FirstOrDefault((authorObj) => authorObj.AuthorId == authorId);
        }
        public void createAuthor(Author author) { }
        public void delete(int authorId) { }
    }
}
