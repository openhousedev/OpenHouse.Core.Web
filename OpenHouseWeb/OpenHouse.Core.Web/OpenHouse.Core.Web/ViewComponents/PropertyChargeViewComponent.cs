using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenHouse.Core.Web.Areas.Identity.Data;
using OpenHouse.Core.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHouse.Core.Web.ViewComponents
{
    public class PropertyChargeViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRentAccountService _rentSvc;

        public PropertyChargeViewComponent(UserManager<ApplicationUser> userManager, IRentAccountService rentSvc)
        {
            _userManager = userManager;
            _rentSvc = rentSvc;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUserId = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedInUserId = loggedInUserId.Id;

            ViewBag.RentAccountId = new SelectList(await _rentSvc.GetRentAccountsAsync(), "rentAccountId", "rentAccount1");
            return View();
        }
    }
}
