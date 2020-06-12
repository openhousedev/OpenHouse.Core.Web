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
    public class AlertsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public AlertsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Alerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<alert>>> Getalert()
        {
            return await _context.alert.ToListAsync();
        }

        // GET: api/Alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<alert>> Getalert(int id)
        {
            var alert = await _context.alert.FindAsync(id);

            if (alert == null)
            {
                return NotFound();
            }

            return alert;
        }

        // PUT: api/Alerts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putalert(int id, alert alert)
        {
            if (id != alert.alertId)
            {
                return BadRequest();
            }

            _context.Entry(alert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alertExists(id))
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

        // POST: api/Alerts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<alert>> Postalert(alert alert)
        {
            _context.alert.Add(alert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getalert", new { id = alert.alertId }, alert);
        }

        // DELETE: api/Alerts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<alert>> Deletealert(int id)
        {
            var alert = await _context.alert.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            _context.alert.Remove(alert);
            await _context.SaveChangesAsync();

            return alert;
        }

        private bool alertExists(int id)
        {
            return _context.alert.Any(e => e.alertId == id);
        }
    }
}
