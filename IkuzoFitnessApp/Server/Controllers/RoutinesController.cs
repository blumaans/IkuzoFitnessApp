﻿using System;
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
    public class RoutinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoutinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Routines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Routine>>> GetRoutines()
        {
          if (_context.Routines == null)
          {
              return NotFound();
          }
            return await _context.Routines.ToListAsync();
        }

        // GET: api/Routines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Routine>> GetRoutine(int id)
        {
          if (_context.Routines == null)
          {
              return NotFound();
          }
            var routine = await _context.Routines.FindAsync(id);

            if (routine == null)
            {
                return NotFound();
            }

            return routine;
        }

        // PUT: api/Routines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutine(int id, Routine routine)
        {
            if (id != routine.Id)
            {
                return BadRequest();
            }

            _context.Entry(routine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutineExists(id))
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

        // POST: api/Routines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Routine>> PostRoutine(Routine routine)
        {
          if (_context.Routines == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Routines'  is null.");
          }
            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutine", new { id = routine.Id }, routine);
        }

        // DELETE: api/Routines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutine(int id)
        {
            if (_context.Routines == null)
            {
                return NotFound();
            }
            var routine = await _context.Routines.FindAsync(id);
            if (routine == null)
            {
                return NotFound();
            }

            _context.Routines.Remove(routine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoutineExists(int id)
        {
            return (_context.Routines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
