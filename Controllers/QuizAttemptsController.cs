using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAttemptsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public QuizAttemptsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/QuizAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizAttempt>>> GetQuizAttempts()
        {
            return await _context.QuizAttempts.ToListAsync();
        }

        // GET: api/QuizAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizAttempt>> GetQuizAttempt(int id)
        {
            var quizAttempt = await _context.QuizAttempts.FindAsync(id);

            if (quizAttempt == null)
            {
                return NotFound();
            }

            return quizAttempt;
        }

        // PUT: api/QuizAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizAttempt(int id, QuizAttempt quizAttempt)
        {
            if (id != quizAttempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(quizAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizAttemptExists(id))
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

        // POST: api/QuizAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizAttempt>> PostQuizAttempt(QuizAttempt quizAttempt)
        {
            _context.QuizAttempts.Add(quizAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizAttempt", new { id = quizAttempt.Id }, quizAttempt);
        }

        // DELETE: api/QuizAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizAttempt(int id)
        {
            var quizAttempt = await _context.QuizAttempts.FindAsync(id);
            if (quizAttempt == null)
            {
                return NotFound();
            }

            _context.QuizAttempts.Remove(quizAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizAttemptExists(int id)
        {
            return _context.QuizAttempts.Any(e => e.Id == id);
        }
    }
}
