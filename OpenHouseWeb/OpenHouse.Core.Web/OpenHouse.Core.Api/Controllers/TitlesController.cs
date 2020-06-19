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
    public class TitlesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public TitlesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Titles
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<title>>> GetTitle()
        {
            return await _context.title.ToListAsync();
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<title>> GetTitle(int id)
        {
            var title = await _context.title.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }

        // PUT: api/Titles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, title title)
        {
            if (id != title.titleId)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!titleExists(id))
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

        // POST: api/Titles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<title>> PostTitle(title title)
        {
            _context.title.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettitle", new { id = title.titleId }, title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<title>> DeleteTitle(int id)
        {
            var title = await _context.title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.title.Remove(title);
            await _context.SaveChangesAsync();

            return title;
        }

        private bool titleExists(int id)
        {
            return _context.title.Any(e => e.titleId == id);
        }
    }
}
