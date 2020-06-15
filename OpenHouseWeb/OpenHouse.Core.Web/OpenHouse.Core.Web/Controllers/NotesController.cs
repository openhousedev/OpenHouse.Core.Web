using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace OpenHouse.Core.Web.Controllers
{
    public class NotesController : Controller
    {
        private readonly UserManager<User> _userManager;
        public NotesController()
        {
        }

        public async Task<IActionResult> _NoteManager()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user
            ViewBag.LoggedInUserId = user.Id;

            return await Task.Run(() => PartialView());
        }
    }
}
