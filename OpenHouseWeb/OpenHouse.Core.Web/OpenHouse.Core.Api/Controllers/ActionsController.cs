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
    public class ActionsController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public ActionsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Actions
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<action>>> GetAction()
        {
            return await _context.action.ToListAsync();
        }

        // GET: api/Actions/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<action>> GetAction(int id)
        {
            var action = await _context.action.FindAsync(id);

            if (action == null)
            {
                return NotFound();
            }

            return action;
        }

        // PUT: api/Actions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAction(int id, action action)
        {
            if (id != action.actionId)
            {
                return BadRequest();
            }

            _context.Entry(action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!actionExists(id))
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

        // POST: api/Actions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<action>> PostAction(action action)
        {
            _context.action.Add(action);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaction", new { id = action.actionId }, action);
        }

        // DELETE: api/Actions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<action>> DeleteAction(int id)
        {
            var action = await _context.action.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            _context.action.Remove(action);
            await _context.SaveChangesAsync();

            return action;
        }

        private bool actionExists(int id)
        {
            return _context.action.Any(e => e.actionId == id);
        }
    }
}
