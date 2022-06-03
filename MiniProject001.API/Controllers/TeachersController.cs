using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject001.DAL.Database;
using MiniProject001.DAL.Database.Models;

namespace MiniProject001.API.Controllers
{
    /// <summary>
    /// {
    ///   "teacherId": 0,
    ///  "name": "Flemming",
    ///  "student": [
    ///    {
    ///      "studentId": 0,
    ///      "name": "Anders",
    ///    },
    ///    {
    ///    "studentId": 0,
    ///      "name": "Ramazan",
    ///    },
    ///    {
    ///    "studentId": 0,
    ///      "name": "Simon",
    ///    }
    ///  ]
    ///}
    ///
    /// {
  ///"teacherId": 1,
  ///"name": "string",
  ///"student": [
  ///  {
  ///    "studentId": 1,
  ///    "name": "Robin"
  ///  }
  ///]
  ///}
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AbContext _context;

        public TeachersController(AbContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
            return await _context.Teacher.Include(t=>t.student).ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.teacherId)
            {
                return BadRequest();
            }
            //_context.Student.first
            // her får vi fat i det objekt som vi gerne vil modificerer
            //_context.Entry(teacher).State = EntityState.Modified; // kun det objekt den er i
            Teacher tempTeacher = _context.Teacher.Include(t => t.student)
                .Single(t => t.teacherId == id);

            tempTeacher.student.AddRange(teacher.student); //tilføje mere, er dette en insert??. NEJ!!

            // hvis den ikke eksisterer.. så skal jeg benytte _context. blablabla



            //_context.Teacher.AddRange(new List<Teacher>()); // flere rækker
            //_context.Teacher.Add(teacher); //insert en ny række

            //Actor tempActor = _context.Actor.Include(a => a.movies).Single(a => a.actorId == id);
            //tempActor.movies.where eller lignende LINQ, der kan du remove dem alle og "bare" sætte ind
            //    eller du kan fjerne de objekter du vil have fjernet en adgangen.
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpPut("teacher2/{id}")]
        public async Task<IActionResult> PutTeacher2(int id, Teacher teacher)
        {
            if (id != teacher.teacherId)
            {
                return BadRequest();
            }

            // her får vi fat i det objekt som vi gerne vil modificerer
            //_context.Entry(teacher).State = EntityState.Modified; // kun det objekt den er i
            Teacher tempTeacher = _context.Teacher.Include(t => t.student)
                .Single(t => t.teacherId == id);
            
            tempTeacher.student.RemoveRange(0, tempTeacher.student.Count());
            tempTeacher.student.AddRange(teacher.student);
            #region
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            #endregion
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            //først tilføj actor / teacher uden min liste
            //2) hent objektet fra databasen.....
            //3) så kan I lægge jeres data "på" som I har valgt fra en dropdown eller lignende
            //Teacher t = new Teacher();
            //t.teacherId = 0;
            //t.name = teacher.name;
            //_context.Teacher.Add(t);
            //hvis vi ikke har returneret en pk fra db, så skal vi hente den først...
            //Actor tempActor = _context.Actor.Include(t => t.student)
            //.Single(t => t.teacherId == pkId); // de data der allerede eksisterer i forvejen
            //tempActor.movies.Add(blablabla);


            _context.Teacher.Add(teacher); // insert into actor values ('asfdsadf')
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher", new { id = teacher.teacherId }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.teacherId == id);
        }
    }
}

//        var book = context.Books
//.Include(p => p.Tags)
//.Single(p => p.Title == "Quantum Networking");

//        var existingTag = context.Tags
//            .Single(p => p.TagId == "Editor's Choice");

//        book.Tags.Add(existingTag);
//        context.SaveChanges();

//_context.Entry(teacher)
//_context.Entry(teacher).State = EntityState.Modified;