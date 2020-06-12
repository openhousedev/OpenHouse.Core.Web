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
    public class TenureTypesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenureTypesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/TenureTypes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenuretype>>> Gettenuretype()
        {
            return await _context.tenuretype.ToListAsync();
        }

        // GET: api/TenureTypes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenuretype>> Gettenuretype(int id)
        {
            var tenuretype = await _context.tenuretype.FindAsync(id);

            if (tenuretype == null)
            {
                return NotFound();
            }

            return tenuretype;
        }

        // PUT: api/TenureTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttenuretype(int id, tenuretype tenuretype)
        {
            if (id != tenuretype.tenureTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tenuretype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenuretypeExists(id))
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

        // POST: api/TenureTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenuretype>> Posttenuretype(tenuretype tenuretype)
        {
            _context.tenuretype.Add(tenuretype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenuretype", new { id = tenuretype.tenureTypeId }, tenuretype);
        }

        // DELETE: api/TenureTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenuretype>> Deletetenuretype(int id)
        {
            var tenuretype = await _context.tenuretype.FindAsync(id);
            if (tenuretype == null)
            {
                return NotFound();
            }

            _context.tenuretype.Remove(tenuretype);
            await _context.SaveChangesAsync();

            return tenuretype;
        }

        private bool tenuretypeExists(int id)
        {
            return _context.tenuretype.Any(e => e.tenureTypeId == id);
        }
    }
}
