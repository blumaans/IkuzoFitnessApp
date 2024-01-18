using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IkuzoFitnessApp.Server.Data;
using IkuzoFitnessApp.Shared.Domain;
using IkuzoFitnessApp.Server.IRepository;

namespace IkuzoFitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressTracksController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProgressTracksController(ApplicationDbContext context)
        public ProgressTracksController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProgressTracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressTrack>>> GetProgressTracks()
        {
            //if (_context.ProgressTracks == null)
            //{
            //    return NotFound();
            //}
            //return await _context.ProgressTracks.ToListAsync();
            var progressTracks = await _unitOfWork.ProgressTracks.GetAll();
            return Ok(progressTracks);
        }

        // GET: api/ProgressTracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressTrack>> GetProgressTrack(int id)
        {
            //if (_context.ProgressTracks == null)
            //{
            //    return NotFound();
            //}
            //  var progressTrack = await _context.ProgressTracks.FindAsync(id);

            var progressTrack = await _unitOfWork.ProgressTracks.Get(q => q.Id == id);

            if (progressTrack == null)
            {
                return NotFound();
            }

            //return progressTrack;
            return Ok(progressTrack);
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

            //_context.Entry(progressTrack).State = EntityState.Modified;
            _unitOfWork.ProgressTracks.Update(progressTrack);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProgressTrackExists(id))
                if (!await ProgressTrackExists(id))
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
            //if (_context.ProgressTracks == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.ProgressTracks'  is null.");
            //}
            //  _context.ProgressTracks.Add(progressTrack);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.ProgressTracks.Insert(progressTrack);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProgressTrack", new { id = progressTrack.Id }, progressTrack);
        }

        // DELETE: api/ProgressTracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressTrack(int id)
        {
            //if (_context.ProgressTracks == null)
            //{
            //    return NotFound();
            //}
            //var progressTrack = await _context.ProgressTracks.FindAsync(id);
            var progressTrack = await _unitOfWork.ProgressTracks.Get(q => q.Id == id);

            if (progressTrack == null)
            {
                return NotFound();
            }

            //_context.ProgressTracks.Remove(progressTrack);
            //await _context.SaveChangesAsync();
            await _unitOfWork.ProgressTracks.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ProgressTrackExists(int id)
        private async Task<bool> ProgressTrackExists(int id)
        {
            //return (_context.ProgressTracks?.Any(e => e.Id == id)).GetValueOrDefault();
            var progressTrack = await _unitOfWork.ProgressTracks.Get(q => q.Id == id);
            return progressTrack != null;
        }
    }
}
