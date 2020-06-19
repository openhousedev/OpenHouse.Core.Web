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
    public class AlertTypesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public AlertTypesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/AlertTypes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<alerttype>>> GetAlertType()
        {
            return await _context.alerttype.ToListAsync();
        }

        // GET: api/AlertTypes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<alerttype>> Getalerttype(int id)
        {
            var alerttype = await _context.alerttype.FindAsync(id);

            if (alerttype == null)
            {
                return NotFound();
            }

            return alerttype;
        }

        // PUT: api/AlertTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertType(int id, alerttype alerttype)
        {
            if (id != alerttype.alertTypeId)
            {
                return BadRequest();
            }

            _context.Entry(alerttype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!alerttypeExists(id))
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

        // POST: api/AlertTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<alerttype>> PostAlertType(alerttype alerttype)
        {
            _context.alerttype.Add(alerttype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getalerttype", new { id = alerttype.alertTypeId }, alerttype);
        }

        // DELETE: api/AlertTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<alerttype>> DeleteAlertType(int id)
        {
            var alerttype = await _context.alerttype.FindAsync(id);
            if (alerttype == null)
            {
                return NotFound();
            }

            _context.alerttype.Remove(alerttype);
            await _context.SaveChangesAsync();

            return alerttype;
        }

        private bool alerttypeExists(int id)
        {
            return _context.alerttype.Any(e => e.alertTypeId == id);
        }
    }
}
