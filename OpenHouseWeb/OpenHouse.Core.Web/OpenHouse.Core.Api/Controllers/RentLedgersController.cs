using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Model.Core.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenHouse.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentLedgersController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public RentLedgersController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/RentLedgers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vwrentledger>>> GetRentLedgers()
        {
            return await _context.vwrentledger.ToListAsync();
        }

        // GET: api/RentLedgers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<vwrentledger>> GetRentLedger(int id)
        {
            var rentledger = await _context.vwrentledger.Where(x => x.rentLedgerId == id).FirstOrDefaultAsync();

            if (rentledger == null)
            {
                return NotFound();
            }

            return rentledger;
        }

        // PUT: api/RentLedgers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentLedger(int id, rentledger rentledger)
        {
            if (id != rentledger.rentLedgerId)
            {
                return BadRequest();
            }

            _context.Entry(rentledger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rentledgerExists(id))
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

        // POST: api/RentLedgers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<rentledger>> PostRentLedger(rentledger rentledger)
        {
            _context.rentledger.Add(rentledger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrentledger", new { id = rentledger.rentLedgerId }, rentledger);
        }

        // DELETE: api/RentLedgers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<rentledger>> DeleteRentLedger(int id)
        {
            var rentledger = await _context.rentledger.FindAsync(id);
            if (rentledger == null)
            {
                return NotFound();
            }

            _context.rentledger.Remove(rentledger);
            await _context.SaveChangesAsync();

            return rentledger;
        }

        private bool rentledgerExists(int id)
        {
            return _context.rentledger.Any(e => e.rentLedgerId == id);
        }
    }
}

