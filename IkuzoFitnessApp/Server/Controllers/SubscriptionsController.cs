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
using IkuzoFitnessApp.Server.Repository;

namespace IkuzoFitnessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public SubscriptionsController(ApplicationDbContext context)
        public SubscriptionsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Subscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscriptions()
        {
            //if (_context.Subscriptions == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Subscriptions.ToListAsync();
            var subscriptions = await _unitOfWork.Subscriptions.GetAll();
            return Ok(subscriptions);
        }

        // GET: api/Subscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            //if (_context.Subscriptions == null)
            //{
            //    return NotFound();
            //}
            //  var subscription = await _context.Subscriptions.FindAsync(id);

            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            //return subscription;
            return Ok(subscription);
        }

        // PUT: api/Subscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }

            //_context.Entry(subscription).State = EntityState.Modified;
            _unitOfWork.Subscriptions.Update(subscription);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!SubscriptionExists(id))
                if (!await SubscriptionExists(id))
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

        // POST: api/Subscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {
            //if (_context.Subscriptions == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
            //}
            //  _context.Subscriptions.Add(subscription);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Subscriptions.Insert(subscription);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSubscription", new { id = subscription.Id }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            //if (_context.Subscriptions == null)
            //{
            //    return NotFound();
            //}
            //var subscription = await _context.Subscriptions.FindAsync(id);\

            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            //_context.Subscriptions.Remove(subscription);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Subscriptions.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        //private bool SubscriptionExists(int id)
        private async Task<bool> SubscriptionExists(int id)
        {
            //return (_context.Subscriptions?.Any(e => e.Id == id)).GetValueOrDefault();
            var subscription = await _unitOfWork.Subscriptions.Get(q => q.Id == id);
            return subscription != null;
        }
    }
}
