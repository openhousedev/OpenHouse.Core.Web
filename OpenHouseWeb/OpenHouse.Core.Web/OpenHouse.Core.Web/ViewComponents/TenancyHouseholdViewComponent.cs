using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenHouse.Core.Services.Interfaces;

namespace GENerate.ViewComponents
{
    [Authorize]
    public class TenancyHouseholdViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITenancyService _tenancySvc;

        public TenancyHouseholdViewComponent(UserManager<ApplicationUser> userManager, ITenancyService tenancySvc)
        {
            _userManager = userManager;
            _tenancySvc = tenancySvc;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUserId = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.LoggedInUserId = loggedInUserId.Id;

            ViewBag.LeadTenantRelationshipId = new SelectList(await _tenancySvc.GetTenantHouseholdRelationshipsAsync(), "relationshipId", "relationship1");
            ViewBag.JointTenantRelationshipId = new SelectList(await _tenancySvc.GetTenantHouseholdRelationshipsAsync(), "relationshipId", "relationship1");

            return View();
        }
    }
}
