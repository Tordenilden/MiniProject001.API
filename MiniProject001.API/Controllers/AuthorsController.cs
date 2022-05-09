using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject001.DAL;
using MiniProject001.DAL.Database;
using MiniProject001.DAL.Database.Models;

namespace MiniProject001.API.Controllers
{
    /// <summary>
    /// 1) HVer gang vi er i Controller skal vi kalde en metode i vores repo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository repo;
        public AuthorsController(IAuthorRepository a)
        {
            repo = a;
        }
        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult> getAllAuthors()
        {
            return Ok(await repo.getAllAuthors()); // Ok kan typecast 98% af alt kode fy ha!!
            //return await _context.Author.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Author>> createAuthor(Author author)
        {
            // i dette lag hvad skal vi her!!

            try
            { // tester om det virker..
                var response = await repo.createAuthor(author);
                if (response != 1) // hvis author ikke blev oprettet
                {
                    return Problem("du har jokket det forkerte sted");
                }
                return Ok(response); // Ok kommer fra actionresult....
                                     // TODO kan man lave Ok om til Created???
            }
            catch (Exception error)
            {
                // kunne være internt - især log hvis det er servere...
                return Problem(error.Message + "vores eget ...");
            }
            //_context.Author.Add(author);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        //AuthorController
        [HttpGet("Flødebolle")]
        public void getAuthor(int tal, string s)
        {
            int tal1 = 9;
        }

        [HttpDelete("{authorId}")] // id
        public async Task<IActionResult> deleteAuthor(int authorId)
        {
            try
            {
                // vi vil gerne have fat i vores repo altid!!
                var response =await repo.deleteAuthor(authorId);
                if(response == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception error)
            {
                return Problem(error.Message);                 
            }

        }
        
        //// GET: api/Authors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Author>> GetAuthor(int id)
        //{
        //    var author = await _context.Author.FindAsync(id);

        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return author;
        //}

        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.AuthorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        ///SWAGGER
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //    AbContext _context = new AbContext();
        //    _context.Author.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        //}


        //// DELETE: api/Authors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAuthor(int id)
        //{
        //    var author = await _context.Author.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Author.Remove(author);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AuthorExists(int id)
        //{
        //    return _context.Author.Any(e => e.AuthorId == id);
        //}
    }
}
