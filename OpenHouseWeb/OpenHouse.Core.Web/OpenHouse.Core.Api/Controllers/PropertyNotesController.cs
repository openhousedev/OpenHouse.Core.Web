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
    public class PropertyNotesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PropertyNotesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/PropertyNotes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<propertynote>>> Getpropertynote()
        {
            return await _context.propertynote.ToListAsync();
        }

        // GET: api/PropertyNotes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<propertynote>> Getpropertynote(int id)
        {
            var propertynote = await _context.propertynote.FindAsync(id);

            if (propertynote == null)
            {
                return NotFound();
            }

            return propertynote;
        }

        // PUT: api/PropertyNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpropertynote(int id, propertynote propertynote)
        {
            if (id != propertynote.propertyNoteId)
            {
                return BadRequest();
            }

            _context.Entry(propertynote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertynoteExists(id))
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

        // POST: api/PropertyNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<propertynote>> Postpropertynote(propertynote propertynote)
        {
            _context.propertynote.Add(propertynote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpropertynote", new { id = propertynote.propertyNoteId }, propertynote);
        }

        // DELETE: api/PropertyNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<propertynote>> Deletepropertynote(int id)
        {
            var propertynote = await _context.propertynote.FindAsync(id);
            if (propertynote == null)
            {
                return NotFound();
            }

            _context.propertynote.Remove(propertynote);
            await _context.SaveChangesAsync();

            return propertynote;
        }

        private bool propertynoteExists(int id)
        {
            return _context.propertynote.Any(e => e.propertyNoteId == id);
        }
    }
}
