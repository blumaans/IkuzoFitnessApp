using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IkuzoFitnessApp.Server.Data;
using IkuzoFitnessApp.Shared.Domain;

namespace IkuzoFitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressTracksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProgressTracksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProgressTracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressTrack>>> GetProgressTracks()
        {
          if (_context.ProgressTracks == null)
          {
              return NotFound();
          }
            return await _context.ProgressTracks.ToListAsync();
        }

        // GET: api/ProgressTracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressTrack>> GetProgressTrack(int id)
        {
          if (_context.ProgressTracks == null)
          {
              return NotFound();
          }
            var progressTrack = await _context.ProgressTracks.FindAsync(id);

            if (progressTrack == null)
            {
                return NotFound();
            }

            return progressTrack;
        }

        // PUT: api/ProgressTracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgressTrack(int id, ProgressTrack progressTrack)
        {
            if (id != progressTrack.Id)
            {
                return BadRequest();
            }

            _context.Entry(progressTrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressTrackExists(id))
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

        // POST: api/ProgressTracks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgressTrack>> PostProgressTrack(ProgressTrack progressTrack)
        {
          if (_context.ProgressTracks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ProgressTracks'  is null.");
          }
            _context.ProgressTracks.Add(progressTrack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgressTrack", new { id = progressTrack.Id }, progressTrack);
        }

        // DELETE: api/ProgressTracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressTrack(int id)
        {
            if (_context.ProgressTracks == null)
            {
                return NotFound();
            }
            var progressTrack = await _context.ProgressTracks.FindAsync(id);
            if (progressTrack == null)
            {
                return NotFound();
            }

            _context.ProgressTracks.Remove(progressTrack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgressTrackExists(int id)
        {
            return (_context.ProgressTracks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
