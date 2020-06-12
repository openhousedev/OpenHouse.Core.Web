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
    public class ActionTypesController : ControllerBase
    {
        private readonly OpenhouseContext _context;

        public ActionTypesController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/ActionTypes
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<actiontype>>> Getactiontype()
        {
            return await _context.actiontype.ToListAsync();
        }

        // GET: api/ActionTypes/5
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<actiontype>> Getactiontype(int id)
        {
            var actiontype = await _context.actiontype.FindAsync(id);

            if (actiontype == null)
            {
                return NotFound();
            }

            return actiontype;
        }

        // PUT: api/ActionTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putactiontype(int id, actiontype actiontype)
        {
            if (id != actiontype.actionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(actiontype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!actiontypeExists(id))
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

        // POST: api/ActionTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<actiontype>> Postactiontype(actiontype actiontype)
        {
            _context.actiontype.Add(actiontype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getactiontype", new { id = actiontype.actionTypeId }, actiontype);
        }

        // DELETE: api/ActionTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<actiontype>> Deleteactiontype(int id)
        {
            var actiontype = await _context.actiontype.FindAsync(id);
            if (actiontype == null)
            {
                return NotFound();
            }

            _context.actiontype.Remove(actiontype);
            await _context.SaveChangesAsync();

            return actiontype;
        }

        private bool actiontypeExists(int id)
        {
            return _context.actiontype.Any(e => e.actionTypeId == id);
        }
    }
}
