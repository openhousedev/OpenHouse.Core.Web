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
    public class ActionViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IActionService _actionSvc;

        public ActionViewComponent(UserManager<User> userManager, IActionService actionSvc)
        {
            _userManager = userManager;
            _actionSvc = actionSvc;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUserId = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedInUserId = loggedInUserId.Id;

            ViewBag.actionTypeId = new SelectList(await _actionSvc.GetActionTypesAsync(), "actionTypeId", "actionType1");

            return View();
        }
    }
}
