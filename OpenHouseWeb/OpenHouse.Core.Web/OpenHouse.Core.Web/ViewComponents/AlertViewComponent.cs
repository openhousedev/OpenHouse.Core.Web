using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using OpenHouse.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GENerate.ViewComponents
{
    [Authorize]
    public class AlertViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAlertService _alertSvc;

        public AlertViewComponent(UserManager<ApplicationUser> userManager, IAlertService alertSvc)
        {
            _alertSvc = alertSvc;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUserId = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedInUserId = loggedInUserId.Id;

            ViewBag.AlertTypeId = new SelectList(await _alertSvc.GetAlertTypesAsync(), "alertTypeId", "alertType1");

            return View();
        }
    }
}
