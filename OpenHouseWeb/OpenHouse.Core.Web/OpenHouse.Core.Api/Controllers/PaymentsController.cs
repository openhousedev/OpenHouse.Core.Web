using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PaymentsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<payment>>> GetPayment()
        {
            return await _context.payment.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<payment>> GetPayment(int id)
        {
            var payment = await _context.payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, payment payment)
        {
            if (id != payment.paymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<payment>> PostPayment(payment payment)
        {
            _context.payment.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment", new { id = payment.paymentId }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<payment>> DeletePayment(int id)
        {
            var payment = await _context.payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.payment.Remove(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        private bool paymentExists(int id)
        {
            return _context.payment.Any(e => e.paymentId == id);
        }
    }
}
