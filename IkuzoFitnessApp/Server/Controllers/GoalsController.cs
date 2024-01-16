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
    public class GoalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Goals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
          if (_context.Goals == null)
          {
              return NotFound();
          }
            return await _context.Goals.ToListAsync();
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goal>> GetGoal(int id)
        {
          if (_context.Goals == null)
          {
              return NotFound();
          }
            var goal = await _context.Goals.FindAsync(id);

            if (goal == null)
            {
                return NotFound();
            }

            return goal;
        }

        // PUT: api/Goals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, Goal goal)
        {
            if (id != goal.Id)
            {
                return BadRequest();
            }

            _context.Entry(goal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(id))
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

        // POST: api/Goals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Goal>> PostGoal(Goal goal)
        {
          if (_context.Goals == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Goals'  is null.");
          }
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoal", new { id = goal.Id }, goal);
        }

        // DELETE: api/Goals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            if (_context.Goals == null)
            {
                return NotFound();
            }
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoalExists(int id)
        {
            return (_context.Goals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
