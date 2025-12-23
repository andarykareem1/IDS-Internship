using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs.Certificates;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CertificatesController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public CertificatesController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/Certificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateDto>>> GetCertificates()
        {
            var certificates = await _context.Certificates
                .Select(c => new CertificateDto
                {
                    CertificateId = c.Id,
                    CourseId = c.CourseId ?? 0,
                    UserId = c.UserId ?? 0,
                    
                    GeneratedAt = c.GeneratedAt
                })
                .ToListAsync();

            return Ok(certificates);
        }


        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateDto>> GetCertificate(int id)
        {
            var certificate = await _context.Certificates
                .Where(c => c.Id == id)
                .Select(c => new CertificateDto
                {
                    CertificateId = c.Id,
                    CourseId = c.CourseId ?? 0,
                    UserId = c.UserId ?? 0,
           
                    GeneratedAt = c.GeneratedAt
                })
                .FirstOrDefaultAsync();

            if (certificate == null)
                return NotFound();

            return Ok(certificate);
        }


        // PUT: api/Certificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(int id, Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return BadRequest();
            }

            _context.Entry(certificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
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

        // POST: api/Certificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificateDto>> PostCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();

            var dto = new CertificateDto
            {
                CertificateId = certificate.Id,
                CourseId = certificate.CourseId ?? 0,
                UserId = certificate.UserId ?? 0,
                GeneratedAt = certificate.GeneratedAt
            };

            return CreatedAtAction(nameof(GetCertificate), new { id = dto.CertificateId }, dto);
        }


        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificates.Any(e => e.Id == id);
        }
    }
}
