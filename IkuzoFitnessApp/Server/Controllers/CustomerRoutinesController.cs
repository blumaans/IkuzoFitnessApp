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
    public class CustomerRoutinesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CustomerRoutinesController(ApplicationDbContext context)
        public CustomerRoutinesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/CustomerRoutines
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<CustomerRoutine>>> GetCustomersPrograms()
        public async Task<IActionResult> GetCustomerRoutines()
        {
            //if (_context.CustomersPrograms == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.CustomersPrograms.ToListAsync();
            var customerRoutines = await _unitOfWork.CustomerRoutines.GetAll();
            return Ok(customerRoutines);
        }

        // GET: api/CustomerRoutines/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<CustomerRoutine>> GetCustomerRoutine(int id)
        public async Task<IActionResult> GetCustomerRoutine(int id)
        {
            //if (_context.CustomersPrograms == null)
            //{
            //    return NotFound();
            //}
            //  var customerRoutine = await _context.CustomersPrograms.FindAsync(id);
            var customerRoutine = await _unitOfWork.CustomerRoutines.Get(q => q.Id == id);

            if (customerRoutine == null)
            {
                return NotFound();
            }

            //return customerRoutine;
            return Ok(customerRoutine);
        }

        // PUT: api/CustomerRoutines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerRoutine(int id, CustomerRoutine customerRoutine)
        {
            if (id != customerRoutine.Id)
            {
                return BadRequest();
            }

            //_context.Entry(customerRoutine).State = EntityState.Modified;
            _unitOfWork.CustomerRoutines.Update(customerRoutine);

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CustomerRoutineExists(id))
                if(!await CustomerRoutineExists(id))
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

        // POST: api/CustomerRoutines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerRoutine>> PostCustomerRoutine(CustomerRoutine customerRoutine)
        {
            //if (_context.CustomersPrograms == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.CustomersPrograms'  is null.");
            //}
            //  _context.CustomersPrograms.Add(customerRoutine);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.CustomerRoutines.Insert(customerRoutine);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetCustomerRoutine", new { id = customerRoutine.Id }, customerRoutine);
        }

        // DELETE: api/CustomerRoutines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerRoutine(int id)
        {
            //if (_context.CustomersPrograms == null)
            //{
            //    return NotFound();
            //}
            //var customerRoutine = await _context.CustomersPrograms.FindAsync(id);
            var customerRoutine = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (customerRoutine == null)
            {
                return NotFound();
            }

            //_context.CustomersPrograms.Remove(customerRoutine);
            //await _context.SaveChangesAsync();
            await _unitOfWork.CustomerRoutines.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CustomerRoutineExists(int id)
        private async Task<bool> CustomerRoutineExists(int id)
        {
            //return (_context.CustomersPrograms?.Any(e => e.Id == id)).GetValueOrDefault();
            var customerRoutine = await _unitOfWork.CustomerRoutines.Get(q => q.Id == id);
            return customerRoutine != null;
        }
    }
}
