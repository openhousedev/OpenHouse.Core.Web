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
    public class TenancyHouseholdsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenancyHouseholdsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/TenancyHouseholds
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenancyhousehold>>> Gettenancyhousehold()
        {
            return await _context.tenancyhousehold.ToListAsync();
        }

        // GET: api/TenancyHouseholds/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenancyhousehold>> Gettenancyhousehold(int id)
        {
            var tenancyhousehold = await _context.tenancyhousehold.FindAsync(id);

            if (tenancyhousehold == null)
            {
                return NotFound();
            }

            return tenancyhousehold;
        }

        // PUT: api/TenancyHouseholds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttenancyhousehold(int id, tenancyhousehold tenancyhousehold)
        {
            if (id != tenancyhousehold.tenancyHouseholdId)
            {
                return BadRequest();
            }

            _context.Entry(tenancyhousehold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenancyhouseholdExists(id))
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

        // POST: api/TenancyHouseholds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenancyhousehold>> Posttenancyhousehold(tenancyhousehold tenancyhousehold)
        {
            _context.tenancyhousehold.Add(tenancyhousehold);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenancyhousehold", new { id = tenancyhousehold.tenancyHouseholdId }, tenancyhousehold);
        }

        // DELETE: api/TenancyHouseholds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenancyhousehold>> Deletetenancyhousehold(int id)
        {
            var tenancyhousehold = await _context.tenancyhousehold.FindAsync(id);
            if (tenancyhousehold == null)
            {
                return NotFound();
            }

            _context.tenancyhousehold.Remove(tenancyhousehold);
            await _context.SaveChangesAsync();

            return tenancyhousehold;
        }

        private bool tenancyhouseholdExists(int id)
        {
            return _context.tenancyhousehold.Any(e => e.tenancyHouseholdId == id);
        }
    }
}
