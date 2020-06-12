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
    public class TenancyNotesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TenancyNotesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/TenancyNotes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<tenancynote>>> Gettenancynote()
        {
            return await _context.tenancynote.ToListAsync();
        }

        // GET: api/TenancyNotes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<tenancynote>> Gettenancynote(int id)
        {
            var tenancynote = await _context.tenancynote.FindAsync(id);

            if (tenancynote == null)
            {
                return NotFound();
            }

            return tenancynote;
        }

        // PUT: api/TenancyNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttenancynote(int id, tenancynote tenancynote)
        {
            if (id != tenancynote.tenancyNoteId)
            {
                return BadRequest();
            }

            _context.Entry(tenancynote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tenancynoteExists(id))
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

        // POST: api/TenancyNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<tenancynote>> Posttenancynote(tenancynote tenancynote)
        {
            _context.tenancynote.Add(tenancynote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettenancynote", new { id = tenancynote.tenancyNoteId }, tenancynote);
        }

        // DELETE: api/TenancyNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tenancynote>> Deletetenancynote(int id)
        {
            var tenancynote = await _context.tenancynote.FindAsync(id);
            if (tenancynote == null)
            {
                return NotFound();
            }

            _context.tenancynote.Remove(tenancynote);
            await _context.SaveChangesAsync();

            return tenancynote;
        }

        private bool tenancynoteExists(int id)
        {
            return _context.tenancynote.Any(e => e.tenancyNoteId == id);
        }
    }
}
