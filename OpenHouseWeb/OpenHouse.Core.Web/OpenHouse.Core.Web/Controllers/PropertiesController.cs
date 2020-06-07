using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Services.Interfaces;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertySvc;

        public PropertiesController(IPropertyService propertySvc)
        {
            _propertySvc = propertySvc;
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

            return View(property);
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
        public async Task<IActionResult> Create([Bind("propertyId,propertyClassId,propertyTypeId,PropertyNum,PropertySubNum,Address1,Address2,Address3,Address4,PostCode,DemolitionDate,CreationDate,LivingRoomQty,SingleBedroomQty,oubleBedroomQty,maxOccupants,updatedByUserID,updatedDT,createdByUserID,createdDT")] property property)
        {
            if (ModelState.IsValid)
            {
                await _propertySvc.AddPropertyAsync(property);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", property.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", property.propertyTypeId);
            return View(property);
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
            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", property.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", property.propertyTypeId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("propertyId,propertyClassId,propertyTypeId,PropertyNum,PropertySubNum,Address1,Address2,Address3,Address4,PostCode,DemolitionDate,CreationDate,LivingRoomQty,SingleBedroomQty,oubleBedroomQty,maxOccupants,updatedByUserID,updatedDT,createdByUserID,createdDT")] property property)
        {
            if (id != property.propertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _propertySvc.UpdatePropertyAsync(property);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await PropertyExists(property.propertyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.propertyClassId = new SelectList(await _propertySvc.GetPropertyClassesAsync(), "propertyClassId", "propertyClass1", property.propertyClassId);
            ViewBag.propertyTypeId = new SelectList(await _propertySvc.GetPropertyTypesAsync(), "propertyTypeId", "propertyType1", property.propertyTypeId);
            return View(property);
        }

        private async Task<bool> PropertyExists(int id)
        {
            return await _propertySvc.PropertyExistsAsync(id);
        }
    }
}
