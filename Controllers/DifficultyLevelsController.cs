using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.DTOs.DifficultyLevels;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyLevelsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public DifficultyLevelsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/DifficultyLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDifficultyLevels()
        {
            var levels = await _context.DifficultyLevels
                .Select(d => new DifficultyLevelDto
                {
                    DifficultyLevelId = d.Id,
                    LevelName = d.DifficultyName ?? string.Empty,
                })
                .ToListAsync();

            return Ok(levels);
        }


        // GET: api/DifficultyLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DifficultyLevelDto>> GetDifficultyLevel(int id)
        {
            var level = await _context.DifficultyLevels
                .Where(d => d.Id == id)
                .Select(d => new DifficultyLevelDto
                {
                    DifficultyLevelId = d.Id,
                    LevelName = d.DifficultyName ?? string.Empty,
                })
                .FirstOrDefaultAsync();

            if (level == null)
                return NotFound();

            return Ok(level);
        }


        // PUT: api/DifficultyLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifficultyLevel(int id, DifficultyLevel difficultyLevel)
        {
            if (id != difficultyLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(difficultyLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifficultyLevelExists(id))
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

        // POST: api/DifficultyLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DifficultyLevel>> PostDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            _context.DifficultyLevels.Add(difficultyLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDifficultyLevel", new { id = difficultyLevel.Id }, difficultyLevel);
        }

        // DELETE: api/DifficultyLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficultyLevel(int id)
        {
            var difficultyLevel = await _context.DifficultyLevels.FindAsync(id);
            if (difficultyLevel == null)
            {
                return NotFound();
            }

            _context.DifficultyLevels.Remove(difficultyLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DifficultyLevelExists(int id)
        {
            return _context.DifficultyLevels.Any(e => e.Id == id);
        }
    }
}
