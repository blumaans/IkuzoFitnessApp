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
    public class WorkoutsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
          if (_context.Workouts == null)
          {
              return NotFound();
          }
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
          if (_context.Workouts == null)
          {
              return NotFound();
          }
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // PUT: api/Workouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
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

        // POST: api/Workouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
          if (_context.Workouts == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Workouts'  is null.");
          }
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = workout.Id }, workout);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            if (_context.Workouts == null)
            {
                return NotFound();
            }
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExists(int id)
        {
            return (_context.Workouts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
