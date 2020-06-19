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
    public class PropertyClassesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PropertyClassesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/PropertyClasses
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<propertyclass>>> GetPropertyClass()
        {
            return await _context.propertyclass.ToListAsync();
        }

        // GET: api/PropertyClasses/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<propertyclass>> GetPropertyClass(int id)
        {
            var propertyclass = await _context.propertyclass.FindAsync(id);

            if (propertyclass == null)
            {
                return NotFound();
            }

            return propertyclass;
        }

        // PUT: api/PropertyClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyClass(int id, propertyclass propertyclass)
        {
            if (id != propertyclass.propertyClassId)
            {
                return BadRequest();
            }

            _context.Entry(propertyclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertyclassExists(id))
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

        // POST: api/PropertyClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<propertyclass>> PostPropertyClass(propertyclass propertyclass)
        {
            _context.propertyclass.Add(propertyclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpropertyclass", new { id = propertyclass.propertyClassId }, propertyclass);
        }

        // DELETE: api/PropertyClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<propertyclass>> DeletePropertyClass(int id)
        {
            var propertyclass = await _context.propertyclass.FindAsync(id);
            if (propertyclass == null)
            {
                return NotFound();
            }

            _context.propertyclass.Remove(propertyclass);
            await _context.SaveChangesAsync();

            return propertyclass;
        }

        private bool propertyclassExists(int id)
        {
            return _context.propertyclass.Any(e => e.propertyClassId == id);
        }
    }
}
