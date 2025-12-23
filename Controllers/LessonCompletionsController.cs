using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LessonCompletionsController : ControllerBase
    {

        private readonly InternshipDbContext _context;

        public LessonCompletionsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/LessonCompletions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonCompletion>>> GetLessonCompletions()
        {
            return await _context.LessonCompletions.ToListAsync();
        }

        // GET: api/LessonCompletions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonCompletion>> GetLessonCompletion(int id)
        {
            var lessonCompletion = await _context.LessonCompletions.FindAsync(id);

            if (lessonCompletion == null)
            {
                return NotFound();
            }

            return lessonCompletion;
        }

        // PUT: api/LessonCompletions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonCompletion(int id, LessonCompletion lessonCompletion)
        {
            if (id != lessonCompletion.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessonCompletion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonCompletionExists(id))
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

        // POST: api/LessonCompletions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LessonCompletion>> PostLessonCompletion(LessonCompletion lessonCompletion)
        {
            _context.LessonCompletions.Add(lessonCompletion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessonCompletion", new { id = lessonCompletion.Id }, lessonCompletion);
        }

        // DELETE: api/LessonCompletions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessonCompletion(int id)
        {
            var lessonCompletion = await _context.LessonCompletions.FindAsync(id);
            if (lessonCompletion == null)
            {
                return NotFound();
            }

            _context.LessonCompletions.Remove(lessonCompletion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonCompletionExists(int id)
        {
            return _context.LessonCompletions.Any(e => e.Id == id);
        }
    }
}
