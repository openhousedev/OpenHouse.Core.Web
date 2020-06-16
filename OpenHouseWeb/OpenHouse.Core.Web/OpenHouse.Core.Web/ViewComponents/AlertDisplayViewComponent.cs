using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using OpenHouse.Core.Services.Interfaces;

namespace GENerate.ViewComponents
{
    [Authorize]
    public class AlertDisplayViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IAlertService _alertSvc;

        public AlertDisplayViewComponent(UserManager<User> userManager, IAlertService alertSvc)
        {
            _userManager = userManager;
            _alertSvc = alertSvc;
        }

        public async Task<IViewComponentResult> InvokeAsync(int tenancyId)
        {
            var loggedInUserId = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedInUserId = loggedInUserId.Id;

            var alerts = await _alertSvc.GetAlertsForTenancyAsync(tenancyId);
            return View(alerts);
        }
    }
}
