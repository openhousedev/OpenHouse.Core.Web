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
    public class UsersController : ControllerBase
    {
        private readonly OpenhouseContext _context;
        public UsersController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<vwuser>>> GetUsers()
        {
            return await _context.vwuser.ToListAsync();
        }

        // GET: api/Users/{GUID}
        [HttpGet("{id}")]
        [EnableQuery()]
        public async Task<ActionResult<vwuser>> GetUser(string id)
        {
            var user = await _context.vwuser.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
