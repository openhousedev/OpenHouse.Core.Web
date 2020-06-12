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
    public class TenancyAlertsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenancyAlertsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/TenancyAlerts
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenancyalert>>> Gettenancyalert()
        {
            return await _context.tenancyalert.ToListAsync();
        }

        // GET: api/TenancyAlerts/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenancyalert>> Gettenancyalert(int id)
        {
            var tenancyalert = await _context.tenancyalert.FindAsync(id);

            if (tenancyalert == null)
            {
                return NotFound();
            }

            return tenancyalert;
        }

        // PUT: api/TenancyAlerts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttenancyalert(int id, tenancyalert tenancyalert)
        {
            if (id != tenancyalert.tenancyAlertId)
            {
                return BadRequest();
            }

            _context.Entry(tenancyalert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenancyalertExists(id))
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

        // POST: api/TenancyAlerts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenancyalert>> Posttenancyalert(tenancyalert tenancyalert)
        {
            _context.tenancyalert.Add(tenancyalert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenancyalert", new { id = tenancyalert.tenancyAlertId }, tenancyalert);
        }

        // DELETE: api/TenancyAlerts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenancyalert>> Deletetenancyalert(int id)
        {
            var tenancyalert = await _context.tenancyalert.FindAsync(id);
            if (tenancyalert == null)
            {
                return NotFound();
            }

            _context.tenancyalert.Remove(tenancyalert);
            await _context.SaveChangesAsync();

            return tenancyalert;
        }

        private bool tenancyalertExists(int id)
        {
            return _context.tenancyalert.Any(e => e.tenancyAlertId == id);
        }
    }
}
