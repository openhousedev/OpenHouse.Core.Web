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
    public class PaymentSourcesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PaymentSourcesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/PaymentSources
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<paymentsource>>> GetPaymentSource()
        {
            return await _context.paymentsource.ToListAsync();
        }

        // GET: api/PaymentSources/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<paymentsource>> GetPaymentSource(int id)
        {
            var paymentsource = await _context.paymentsource.FindAsync(id);

            if (paymentsource == null)
            {
                return NotFound();
            }

            return paymentsource;
        }

        // PUT: api/PaymentSources/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentSource(int id, paymentsource paymentsource)
        {
            if (id != paymentsource.paymentSourceId)
            {
                return BadRequest();
            }

            _context.Entry(paymentsource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentsourceExists(id))
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

        // POST: api/PaymentSources
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<paymentsource>> PostPaymentSource(paymentsource paymentsource)
        {
            _context.paymentsource.Add(paymentsource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpaymentsource", new { id = paymentsource.paymentSourceId }, paymentsource);
        }

        // DELETE: api/PaymentSources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<paymentsource>> DeletePaymentSource(int id)
        {
            var paymentsource = await _context.paymentsource.FindAsync(id);
            if (paymentsource == null)
            {
                return NotFound();
            }

            _context.paymentsource.Remove(paymentsource);
            await _context.SaveChangesAsync();

            return paymentsource;
        }

        private bool paymentsourceExists(int id)
        {
            return _context.paymentsource.Any(e => e.paymentSourceId == id);
        }
    }
}
