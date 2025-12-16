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
    public class LessonAttachmentsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public LessonAttachmentsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/LessonAttachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonAttachment>>> GetLessonAttachments()
        {
            return await _context.LessonAttachments.ToListAsync();
        }

        // GET: api/LessonAttachments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonAttachment>> GetLessonAttachment(int id)
        {
            var lessonAttachment = await _context.LessonAttachments.FindAsync(id);

            if (lessonAttachment == null)
            {
                return NotFound();
            }

            return lessonAttachment;
        }

        // PUT: api/LessonAttachments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonAttachment(int id, LessonAttachment lessonAttachment)
        {
            if (id != lessonAttachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessonAttachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonAttachmentExists(id))
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

        // POST: api/LessonAttachments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LessonAttachment>> PostLessonAttachment(LessonAttachment lessonAttachment)
        {
            _context.LessonAttachments.Add(lessonAttachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessonAttachment", new { id = lessonAttachment.Id }, lessonAttachment);
        }

        // DELETE: api/LessonAttachments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLessonAttachment(int id)
        {
            var lessonAttachment = await _context.LessonAttachments.FindAsync(id);
            if (lessonAttachment == null)
            {
                return NotFound();
            }

            _context.LessonAttachments.Remove(lessonAttachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonAttachmentExists(int id)
        {
            return _context.LessonAttachments.Any(e => e.Id == id);
        }
    }
}
