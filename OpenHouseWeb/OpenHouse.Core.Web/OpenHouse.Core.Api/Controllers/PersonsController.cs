using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Persons
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<vwperson> GetPersons()
        {
            return _context.vwperson;
        }
    }
}
