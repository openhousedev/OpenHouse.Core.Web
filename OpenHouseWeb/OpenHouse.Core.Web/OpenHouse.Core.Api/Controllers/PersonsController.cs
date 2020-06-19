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
    public class PersonsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public PersonsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/people
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<person>>> GetPerson()
        {
            return await _context.person.ToListAsync();
        }

        // GET: api/people/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<person>> GetPerson(int id)
        {
            var person = await _context.person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/people/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, person person)
        {
            if (id != person.personId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personExists(id))
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

        // POST: api/people
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<person>> PostPerson(person person)
        {
            _context.person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getperson", new { id = person.personId }, person);
        }

        // DELETE: api/people/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<person>> DeletePerson(int id)
        {
            var person = await _context.person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.person.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool personExists(int id)
        {
            return _context.person.Any(e => e.personId == id);
        }
    }
}
