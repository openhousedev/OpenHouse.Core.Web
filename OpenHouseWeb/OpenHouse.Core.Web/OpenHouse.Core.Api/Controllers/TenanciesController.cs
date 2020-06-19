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
    public class TenanciesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenanciesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Tenancies
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenancy>>> GetTenancy()
        {
            return await _context.tenancy.ToListAsync();
        }

        // GET: api/Tenancies/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenancy>> GetTenancy(int id)
        {
            var tenancy = await _context.tenancy.FindAsync(id);

            if (tenancy == null)
            {
                return NotFound();
            }

            return tenancy;
        }

        // PUT: api/Tenancies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenancy(int id, tenancy tenancy)
        {
            if (id != tenancy.tenancyId)
            {
                return BadRequest();
            }

            _context.Entry(tenancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenancyExists(id))
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

        // POST: api/Tenancies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenancy>> PostTenancy(tenancy tenancy)
        {
            _context.tenancy.Add(tenancy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenancy", new { id = tenancy.tenancyId }, tenancy);
        }

        // DELETE: api/Tenancies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenancy>> DeleteTenancy(int id)
        {
            var tenancy = await _context.tenancy.FindAsync(id);
            if (tenancy == null)
            {
                return NotFound();
            }

            _context.tenancy.Remove(tenancy);
            await _context.SaveChangesAsync();

            return tenancy;
        }

        private bool tenancyExists(int id)
        {
            return _context.tenancy.Any(e => e.tenancyId == id);
        }
    }
}
