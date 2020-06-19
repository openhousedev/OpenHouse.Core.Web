using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.OData;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PropertiesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<property>>> GetProperty()
        {
            return await _context.property.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<property>> GetProperty(int id)
        {
            var @property = await _context.property.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, property @property)
        {
            if (id != @property.propertyId)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertyExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<property>> PostProperty(property @property)
        {
            _context.property.Add(@property);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty", new { id = @property.propertyId }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<property>> DeleteProperty(int id)
        {
            var @property = await _context.property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.property.Remove(@property);
            await _context.SaveChangesAsync();

            return @property;
        }

        private bool propertyExists(int id)
        {
            return _context.property.Any(e => e.propertyId == id);
        }
    }
}
