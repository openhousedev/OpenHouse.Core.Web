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
    public class PropertyTypesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PropertyTypesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<propertytype>>> Getpropertytype()
        {
            return await _context.propertytype.ToListAsync();
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<propertytype>> Getpropertytype(int id)
        {
            var propertytype = await _context.propertytype.FindAsync(id);

            if (propertytype == null)
            {
                return NotFound();
            }

            return propertytype;
        }

        // PUT: api/PropertyTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpropertytype(int id, propertytype propertytype)
        {
            if (id != propertytype.propertyTypeId)
            {
                return BadRequest();
            }

            _context.Entry(propertytype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertytypeExists(id))
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

        // POST: api/PropertyTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<propertytype>> Postpropertytype(propertytype propertytype)
        {
            _context.propertytype.Add(propertytype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpropertytype", new { id = propertytype.propertyTypeId }, propertytype);
        }

        // DELETE: api/PropertyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<propertytype>> Deletepropertytype(int id)
        {
            var propertytype = await _context.propertytype.FindAsync(id);
            if (propertytype == null)
            {
                return NotFound();
            }

            _context.propertytype.Remove(propertytype);
            await _context.SaveChangesAsync();

            return propertytype;
        }

        private bool propertytypeExists(int id)
        {
            return _context.propertytype.Any(e => e.propertyTypeId == id);
        }
    }
}
