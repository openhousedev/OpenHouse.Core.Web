using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentAccountsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public RentAccountsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/RentAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<rentaccount>>> Getrentaccount()
        {
            return await _context.rentaccount.ToListAsync();
        }

        // GET: api/RentAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<rentaccount>> Getrentaccount(int id)
        {
            var rentaccount = await _context.rentaccount.FindAsync(id);

            if (rentaccount == null)
            {
                return NotFound();
            }

            return rentaccount;
        }

        // PUT: api/RentAccounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrentaccount(int id, rentaccount rentaccount)
        {
            if (id != rentaccount.rentAccountId)
            {
                return BadRequest();
            }

            _context.Entry(rentaccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rentaccountExists(id))
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

        // POST: api/RentAccounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<rentaccount>> Postrentaccount(rentaccount rentaccount)
        {
            _context.rentaccount.Add(rentaccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrentaccount", new { id = rentaccount.rentAccountId }, rentaccount);
        }

        // DELETE: api/RentAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<rentaccount>> Deleterentaccount(int id)
        {
            var rentaccount = await _context.rentaccount.FindAsync(id);
            if (rentaccount == null)
            {
                return NotFound();
            }

            _context.rentaccount.Remove(rentaccount);
            await _context.SaveChangesAsync();

            return rentaccount;
        }

        private bool rentaccountExists(int id)
        {
            return _context.rentaccount.Any(e => e.rentAccountId == id);
        }
    }
}
