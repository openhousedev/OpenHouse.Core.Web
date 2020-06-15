using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Core.Web.Areas.Identity.Data;
using OpenHouse.Core.Web.Models;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPropertyService _propertySvc;
        private readonly ITenancyService _tenancySvc;
        private readonly IPersonService _personSvc;
        private readonly IActionService _actionSvc;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, IPropertyService propertySvc, ITenancyService tenancySvc, IPersonService personSvc, IActionService actionSvc, UserManager<User> userManager)
        {
            _logger = logger;
            _propertySvc = propertySvc;
            _tenancySvc = tenancySvc;
            _personSvc = personSvc;
            _actionSvc = actionSvc;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var actions = await _actionSvc.GetOpenActionsForUserAsync(user.Id);
            ViewBag.OutstandingActionsCount = actions.Count();

            return View(actions);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
