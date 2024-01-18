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
    public class ExercisesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ExercisesController(ApplicationDbContext context)
        public ExercisesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            //if (_context.Exercises == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Exercises.ToListAsync();
            var exercises = await _unitOfWork.Exercises.GetAll();
            return Ok(exercises);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            //if (_context.Exercises == null)
            //{
            //    return NotFound();
            //}
            //  var exercise = await _context.Exercises.FindAsync(id);

            var exercise = await _unitOfWork.Exercises.Get(q => q.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            //return exercise;
            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            //_context.Entry(exercise).State = EntityState.Modified;
            _unitOfWork.Exercises.Update(exercise);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ExerciseExists(id))
                if (!await ExerciseExists(id))
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
        {
            //if (_context.Exercises == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Exercises'  is null.");
            //}
            //  _context.Exercises.Add(exercise);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Exercises.Insert(exercise);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            //if (_context.Exercises == null)
            //{
            //    return NotFound();
            //}
            //var exercise = await _context.Exercises.FindAsync(id);

            var exercise = await _unitOfWork.Exercises.Get(q => q.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            //_context.Exercises.Remove(exercise);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Exercises.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ExerciseExists(int id)
        private async Task<bool> ExerciseExists(int id)
        {
            //return (_context.Exercises?.Any(e => e.Id == id)).GetValueOrDefault();
            var exercise = await _unitOfWork.Exercises.Get(q => q.Id == id);
            return exercise != null;
        }
    }
}
