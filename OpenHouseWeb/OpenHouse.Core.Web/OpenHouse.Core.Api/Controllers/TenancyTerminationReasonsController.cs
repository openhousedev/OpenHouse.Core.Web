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
    public class TenancyTerminationReasonsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenancyTerminationReasonsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/TenancyTerminationReasons
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenancyterminationreason>>> Gettenancyterminationreason()
        {
            return await _context.tenancyterminationreason.ToListAsync();
        }

        // GET: api/TenancyTerminationReasons/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenancyterminationreason>> Gettenancyterminationreason(int id)
        {
            var tenancyterminationreason = await _context.tenancyterminationreason.FindAsync(id);

            if (tenancyterminationreason == null)
            {
                return NotFound();
            }

            return tenancyterminationreason;
        }

        // PUT: api/TenancyTerminationReasons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttenancyterminationreason(int id, tenancyterminationreason tenancyterminationreason)
        {
            if (id != tenancyterminationreason.tenancyTerminationReasonId)
            {
                return BadRequest();
            }

            _context.Entry(tenancyterminationreason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenancyterminationreasonExists(id))
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

        // POST: api/TenancyTerminationReasons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenancyterminationreason>> Posttenancyterminationreason(tenancyterminationreason tenancyterminationreason)
        {
            _context.tenancyterminationreason.Add(tenancyterminationreason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenancyterminationreason", new { id = tenancyterminationreason.tenancyTerminationReasonId }, tenancyterminationreason);
        }

        // DELETE: api/TenancyTerminationReasons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenancyterminationreason>> Deletetenancyterminationreason(int id)
        {
            var tenancyterminationreason = await _context.tenancyterminationreason.FindAsync(id);
            if (tenancyterminationreason == null)
            {
                return NotFound();
            }

            _context.tenancyterminationreason.Remove(tenancyterminationreason);
            await _context.SaveChangesAsync();

            return tenancyterminationreason;
        }

        private bool tenancyterminationreasonExists(int id)
        {
            return _context.tenancyterminationreason.Any(e => e.tenancyTerminationReasonId == id);
        }
    }
}
