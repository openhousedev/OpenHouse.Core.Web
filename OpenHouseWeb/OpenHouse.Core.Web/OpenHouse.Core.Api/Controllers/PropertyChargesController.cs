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
    public class PropertyChargesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PropertyChargesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/PropertyCharges
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<propertycharge>>> GetPropertyCharge()
        {
            return await _context.propertycharge.ToListAsync();
        }

        // GET: api/PropertyCharges/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<propertycharge>> GetPropertyCharge(int id)
        {
            var propertycharge = await _context.propertycharge.FindAsync(id);

            if (propertycharge == null)
            {
                return NotFound();
            }

            return propertycharge;
        }

        // PUT: api/PropertyCharges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyCharge(int id, propertycharge propertycharge)
        {
            if (id != propertycharge.propertyChargeId)
            {
                return BadRequest();
            }

            _context.Entry(propertycharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertychargeExists(id))
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

        // POST: api/PropertyCharges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<propertycharge>> PostPropertyCharge(propertycharge propertycharge)
        {
            _context.propertycharge.Add(propertycharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpropertycharge", new { id = propertycharge.propertyChargeId }, propertycharge);
        }

        // DELETE: api/PropertyCharges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<propertycharge>> DeletePropertyCharge(int id)
        {
            var propertycharge = await _context.propertycharge.FindAsync(id);
            if (propertycharge == null)
            {
                return NotFound();
            }

            _context.propertycharge.Remove(propertycharge);
            await _context.SaveChangesAsync();

            return propertycharge;
        }

        private bool propertychargeExists(int id)
        {
            return _context.propertycharge.Any(e => e.propertyChargeId == id);
        }
    }
}
