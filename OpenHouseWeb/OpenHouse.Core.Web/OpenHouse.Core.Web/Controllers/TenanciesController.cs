using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace OpenHouse.Core.Web.Controllers
{
    [Authorize]
    public class TenanciesController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ITenancyService _tenancySvc;
        private readonly IPropertyService _propertySvc;
        private readonly IActionService _actionSvc;
        private readonly OpenhouseContext _context;
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public TenanciesController(IConfiguration config, ITenancyService tenancySvc, IPropertyService propertySvc, IActionService actionSvc, UserManager<User> userManager)
        {
            _config = config;
            _tenancySvc = tenancySvc;
            _propertySvc = propertySvc;
            _actionSvc = actionSvc;
            _userManager = userManager;

            //AutoMapper mapping config
            _mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<tenancy, TenancyViewModel>();
                cfg.CreateMap<TenancyViewModel, tenancy>();
            });

            //Create mapper instance
            _mapper = _mapperConfig.CreateMapper();
        }

        // GET Tenancies/_TenancySearch
        public async Task<IActionResult> _TenancySearch(string searchString, string displayType)
        {
            var tenancies = await _tenancySvc.GetTenanciesAsync(searchString);

            return PartialView(tenancies);
        }

        // GET: Tenancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TenancyViewModel tenancyVM = new TenancyViewModel();
            var _tenancy = await _tenancySvc.GetTenancyAsync(id.Value);

            if (_tenancy == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user
            tenancyVM = _mapper.Map<TenancyViewModel>(_tenancy); //Map tenancy object to ViewModel
              
            //Get created by & update by username
            User createByUser = await _userManager.FindByIdAsync(tenancyVM.createdByUserID);
            tenancyVM.createdByUsername = createByUser.UserName;

            User updatedByUser = await _userManager.FindByIdAsync(tenancyVM.updatedByUserID);
            tenancyVM.updatedByUsername = updatedByUser.UserName;

            tenancyVM.tenancyhousehold = await _tenancySvc.GetTenancyHouseholdAsync(tenancyVM.tenancyId); //Get household data for tenancy
            tenancyVM.property = await _propertySvc.GetPropertyViewAsync(tenancyVM.propertyId.Value); //Get property view data for tenancy
            tenancyVM.actions = await _actionSvc.GetActionsForTenancyAsync(tenancyVM.tenancyId); //Get actions data for tenancy

            ViewBag.ApiLocation = _config["APILocation"]; //Set API location URL
            ViewBag.LoggedInUserId = user.Id; //Set logged in user Id

            return View(tenancyVM);
        }

        // GET: Tenancies/Create
        public async Task<IActionResult> Create()
        {
            ViewData["terminationReasonId"] = new SelectList(await _tenancySvc.GetTenancyterminationreasonsAsync(), "tenancyTerminationReasonId", "terminationReason");
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureType1");

            return View();
        }

        // POST: Tenancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tenancyId,propertyId,leadTenantPersonId,jointTenantPersonId,tenureTypeId,startDate,terminationDate,terminationReasonId,updatedByUserID,updatedDT,createdByUserID,createdDT")] TenancyViewModel tenancyVM)
        {
            if (ModelState.IsValid)
            {
                DateTime recordDT = DateTime.Now;
                var tenancy = _mapper.Map<tenancy>(tenancyVM); //Map viewmodel values to tenancy model object
                var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user

                //Set created by & updated by values for record
                tenancy.createdByUserID = user.Id;
                tenancy.createdDT = DateTime.Now;
                tenancy.updatedByUserID = user.Id;
                tenancy.updatedDT = DateTime.Now;

                int newTenancyId = await _tenancySvc.AddTenancyAsync(tenancy);
                return RedirectToAction(nameof(Details), new { @id = newTenancyId });
            }

            ViewData["terminationReasonId"] = new SelectList(await _tenancySvc.GetTenancyterminationreasonsAsync(), "tenancyTerminationReasonId", "terminationReason", tenancyVM.terminationReasonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureTypeId", tenancyVM.tenureTypeId);
            return View(tenancyVM);
        }

        // GET: Tenancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenancy = await _tenancySvc.GetTenancyAsync(id.Value);
            if (tenancy == null)
            {
                return NotFound();
            }

            TenancyViewModel tenancyVM = new TenancyViewModel();
            tenancyVM = _mapper.Map<TenancyViewModel>(tenancy);
            tenancyVM.property = await _propertySvc.GetPropertyViewAsync(tenancyVM.propertyId.Value);

            ViewData["terminationReasonId"] = new SelectList(await _tenancySvc.GetTenancyterminationreasonsAsync(), "tenancyTerminationReasonId", "terminationReason", tenancyVM.terminationReasonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureType1", tenancy.tenureTypeId);
            return View(tenancyVM);
        }

        // POST: Tenancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tenancyId,propertyId,leadTenantPersonId,jointTenantPersonId,tenureTypeId,startDate,terminationDate,terminationReasonId,updatedByUserID,updatedDT,createdByUserID,createdDT")] TenancyViewModel tenancyVM)
        {
            if (id != tenancyVM.tenancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tenancy = _mapper.Map<tenancy>(tenancyVM);

                    var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user

                    //Set created by & updated by values for record
                    tenancy.updatedByUserID = user.Id;
                    tenancy.updatedDT = DateTime.Now;

                    await _tenancySvc.UpdateTenancyAsync(tenancy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tenancyExists(tenancyVM.tenancyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { @id = tenancyVM.tenancyId });
            }

            ViewData["terminationReasonId"] = new SelectList(await _tenancySvc.GetTenancyterminationreasonsAsync(), "tenancyTerminationReasonId", "terminationReason", tenancyVM.terminationReasonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureType1", tenancyVM.tenureTypeId);
            return View(tenancyVM);
        }

        // GET: Tenancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenancy = await _tenancySvc.GetTenancyAsync(id.Value);

            if (tenancy == null)
            {
                return NotFound();
            }

            return View(tenancy);
        }

        // POST: Tenancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenancy = await _context.tenancy.FindAsync(id);
            _context.tenancy.Remove(tenancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tenancyExists(int id)
        {
            return _context.tenancy.Any(e => e.tenancyId == id);
        }
    }
}
