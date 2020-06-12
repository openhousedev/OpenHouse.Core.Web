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
    public class NotesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public NotesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<note>>> Getnote()
        {
            return await _context.note.ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<note>> Getnote(int id)
        {
            var note = await _context.note.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnote(int id, note note)
        {
            if (id != note.noteId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!noteExists(id))
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

        // POST: api/Notes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<note>> Postnote(note note)
        {
            _context.note.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnote", new { id = note.noteId }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<note>> Deletenote(int id)
        {
            var note = await _context.note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.note.Remove(note);
            await _context.SaveChangesAsync();

            return note;
        }

        private bool noteExists(int id)
        {
            return _context.note.Any(e => e.noteId == id);
        }
    }
}
