using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Web.Areas.Identity.Data;

namespace OpenHouse.Core.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> _UserSelector()
        {
            return await Task.Run(() => PartialView());
        }

        public async Task<IActionResult> _UserSearch(string searchString)
        {
            var users = await _userManager.Users.Where(u => u.UserName.ToLower().Contains(searchString)).ToListAsync();

            return PartialView(users);
        }
    }
}
