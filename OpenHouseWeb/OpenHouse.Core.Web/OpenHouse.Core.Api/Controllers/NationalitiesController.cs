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
    public class NationalitiesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public NationalitiesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Nationalities
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<nationality>>> GetNationality()
        {
            return await _context.nationality.ToListAsync();
        }

        // GET: api/Nationalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<nationality>> GetNationality(int id)
        {
            var nationality = await _context.nationality.FindAsync(id);

            if (nationality == null)
            {
                return NotFound();
            }

            return nationality;
        }

        // PUT: api/Nationalities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [EnableQuery()]
        public async Task<IActionResult> PutNationality(int id, nationality nationality)
        {
            if (id != nationality.nationalityId)
            {
                return BadRequest();
            }

            _context.Entry(nationality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nationalityExists(id))
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

        // POST: api/Nationalities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<nationality>> PostNationality(nationality nationality)
        {
            _context.nationality.Add(nationality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnationality", new { id = nationality.nationalityId }, nationality);
        }

        // DELETE: api/Nationalities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<nationality>> DeleteNationality(int id)
        {
            var nationality = await _context.nationality.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }

            _context.nationality.Remove(nationality);
            await _context.SaveChangesAsync();

            return nationality;
        }

        private bool nationalityExists(int id)
        {
            return _context.nationality.Any(e => e.nationalityId == id);
        }
    }
}
