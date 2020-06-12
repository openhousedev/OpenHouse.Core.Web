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
    public class RelationshipsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public RelationshipsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Relationships
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<relationship>>> Getrelationship()
        {
            return await _context.relationship.ToListAsync();
        }

        // GET: api/Relationships/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<relationship>> Getrelationship(int id)
        {
            var relationship = await _context.relationship.FindAsync(id);

            if (relationship == null)
            {
                return NotFound();
            }

            return relationship;
        }

        // PUT: api/Relationships/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrelationship(int id, relationship relationship)
        {
            if (id != relationship.relationshipId)
            {
                return BadRequest();
            }

            _context.Entry(relationship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!relationshipExists(id))
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

        // POST: api/Relationships
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<relationship>> Postrelationship(relationship relationship)
        {
            _context.relationship.Add(relationship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrelationship", new { id = relationship.relationshipId }, relationship);
        }

        // DELETE: api/Relationships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<relationship>> Deleterelationship(int id)
        {
            var relationship = await _context.relationship.FindAsync(id);
            if (relationship == null)
            {
                return NotFound();
            }

            _context.relationship.Remove(relationship);
            await _context.SaveChangesAsync();

            return relationship;
        }

        private bool relationshipExists(int id)
        {
            return _context.relationship.Any(e => e.relationshipId == id);
        }
    }
}
