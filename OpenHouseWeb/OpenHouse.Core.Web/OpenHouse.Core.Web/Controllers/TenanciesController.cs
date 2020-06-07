﻿using System;
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
    public class TenanciesController : Controller
    {
        private readonly ITenancyService _tenancySvc;
        private readonly OpenhouseContext _context;
        public TenanciesController(ITenancyService tenancySvc, OpenhouseContext context)
        {
            _tenancySvc = tenancySvc;
            _context = context;
        }

        // GET: Tenancies/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Tenancies/Create
        public async Task<IActionResult> Create()
        {
            ViewData["jointTenantPersonId"] = new SelectList(_context.vwperson, "personId", "fullName");
            ViewData["leadTenantPersonId"] = new SelectList(_context.vwperson, "personId", "fullName");
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureType1");
            return View();
        }

        // POST: Tenancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tenancyId,propertyId,leadTenantPersonId,jointTenantPersonId,tenureTypeId,startDate,terminationDate,terminationReasonId,updatedByUserID,updatedDT,createdByUserID,createdDT")] tenancy tenancy)
        {
            if (ModelState.IsValid)
            {
                await _tenancySvc.AddTenancyAsync(tenancy);
                return RedirectToAction(nameof(Index));
            }
            ViewData["jointTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.jointTenantPersonId);
            ViewData["leadTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.leadTenantPersonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureTypeId", tenancy.tenureTypeId);
            return View(tenancy);
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
            ViewData["jointTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.jointTenantPersonId);
            ViewData["leadTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.leadTenantPersonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureTypeId", tenancy.tenureTypeId);
            return View(tenancy);
        }

        // POST: Tenancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tenancyId,propertyId,leadTenantPersonId,jointTenantPersonId,tenureTypeId,startDate,terminationDate,terminationReasonId,updatedByUserID,updatedDT,createdByUserID,createdDT")] tenancy tenancy)
        {
            if (id != tenancy.tenancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _tenancySvc.UpdateTenancyAsync(tenancy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tenancyExists(tenancy.tenancyId))
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
            ViewData["jointTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.jointTenantPersonId);
            ViewData["leadTenantPersonId"] = new SelectList(_context.person, "personId", "personId", tenancy.leadTenantPersonId);
            ViewData["tenureTypeId"] = new SelectList(await _tenancySvc.GetTenuretypesAsync(), "tenureTypeId", "tenureTypeId", tenancy.tenureTypeId);
            return View(tenancy);
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