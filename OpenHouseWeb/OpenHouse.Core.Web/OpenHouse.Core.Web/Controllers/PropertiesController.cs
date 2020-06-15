using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PropertiesController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IPropertyService _propertySvc;
        private readonly ITenancyService _tenancySvc;
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PropertiesController(IConfiguration config, IPropertyService propertySvc, ITenancyService tenancySvc, UserManager<User> userManager)
        {
            //Assign services
            _propertySvc = propertySvc;
            _tenancySvc = tenancySvc;
            _userManager = userManager;

            //AutoMapper mapping config
            _mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<property, PropertyViewModel>();
                cfg.CreateMap<PropertyViewModel, property>();
            });

            //Create mapper instance
            _mapper = _mapperConfig.CreateMapper();
        }

        // GET: Properties/_PropertySearch
        public async Task<IActionResult> _PropertySearch(string searchString, string displayType)
        {
            var properties = await _propertySvc.GetPropertiesAsync(searchString);
            ViewBag.DisplayType = displayType;

            return PartialView(properties);
        }

        // GET: Properties/_PropertySelector
        public async Task<IActionResult> _PropertySelector()
        {
            return await Task.Run(() => View());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _propertySvc.GetPropertyAsync(id.Value);

            if (property == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user
            PropertyViewModel propertyVM = _mapper.Map<PropertyViewModel>(property); //Map property model object to viewmodel
            propertyVM.tenancyHistory = await _tenancySvc.GetTenanciesForPropertyIdAsync(id.Value); //Get tenancy history for property

            //Get created by & update by username
            User createByUser = await _userManager.FindByIdAsync(propertyVM.createdByUserID);
            propertyVM.createdByUsername = createByUser.UserName;

            User updatedByUser = await _userManager.FindByIdAsync(propertyVM.updatedByUserID);
            propertyVM.updatedByUsername = updatedByUser.UserName;

            ViewBag.ApiLocation = _config["APILocation"]; //Set API location URL
            ViewBag.LoggedInUserId = user.Id; //Set logged in user Id

            return View(propertyVM);
        }

        // GET: Properties/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1");
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("propertyId,propertyClassId,propertyTypeId,propertyNum,propertySubNum,address1,address2,address3,address4,postCode,demolitionDate,creationDate,livingRoomQty,singleBedroomQty,doubleBedroomQty,maxOccupants,updatedByUserID,updatedDT,createdByUserID,createdDT")] PropertyViewModel propertyVM)
        {
            if (ModelState.IsValid)
            {
                DateTime recordDT = DateTime.Now;
                var _property = _mapper.Map<property>(propertyVM); //Map viewmodel to property model object

                var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user

                //Set created by & updated by values for record
                _property.updatedByUserID = user.Id;
                _property.updatedDT = recordDT;
                _property.createdByUserID = user.Id;
                _property.createdDT = recordDT;

                await _propertySvc.AddPropertyAsync(_property);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", propertyVM.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", propertyVM.propertyTypeId);
            return View(propertyVM);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _propertySvc.GetPropertyAsync(id.Value);
            if (property == null)
            {
                return NotFound();
            }

            PropertyViewModel propertyVM = _mapper.Map<PropertyViewModel>(property);

            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", property.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", property.propertyTypeId);
            return View(propertyVM);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("propertyId,propertyClassId,propertyTypeId,propertyNum,propertySubNum,address1,address2,address3,address4,postCode,demolitionDate,creationDate,livingRoomQty,singleBedroomQty,doubleBedroomQty,maxOccupants,updatedByUserID,updatedDT,createdByUserID,createdDT")] PropertyViewModel propertyVM)
        {
            if (id != propertyVM.propertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _property = _mapper.Map<property>(propertyVM); //Map viewmodel to property model object

                    var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user

                    //Set created by & updated by values for record
                    _property.updatedByUserID = user.Id;
                    _property.updatedDT = DateTime.Now;

                    await _propertySvc.UpdatePropertyAsync(_property); //Update property async
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await PropertyExists(propertyVM.propertyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details),new { @id = propertyVM.propertyId });
            }
            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", propertyVM.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", propertyVM.propertyTypeId);

            return View(propertyVM);
        }

        private async Task<bool> PropertyExists(int id)
        {
            return await _propertySvc.PropertyExistsAsync(id);
        }
    }
}
