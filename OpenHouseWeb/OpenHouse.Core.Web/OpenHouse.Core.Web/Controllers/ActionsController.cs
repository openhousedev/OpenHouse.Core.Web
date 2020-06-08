using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Web.Controllers
{
    public class ActionsController : Controller
    {
        private readonly OpenhouseContext _context;

        public ActionsController(OpenhouseContext context)
        {
            _context = context;
        }

        // GET: Actions
        public async Task<IActionResult> Index()
        {
            var openhouseContext = _context.action.Include(a => a.actionType).Include(a => a.tenancy);
            return View(await openhouseContext.ToListAsync());
        }

        // GET: Actions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.action
                .Include(a => a.actionType)
                .Include(a => a.tenancy)
                .FirstOrDefaultAsync(m => m.actionId == id);
            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // GET: Actions/Create
        public IActionResult Create()
        {
            ViewData["actionTypeId"] = new SelectList(_context.actiontype, "actionTypeId", "actionTypeId");
            ViewData["tenancyId"] = new SelectList(_context.tenancy, "tenancyId", "tenancyId");
            return View();
        }

        // POST: Actions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("actionId,actionTypeId,tenancyId,assignedUserId,actionDueDate,actionCompletedDate,updatedByUserID,updatedDT,createdByUserID,createdDT")] action action)
        {
            if (ModelState.IsValid)
            {
                _context.Add(action);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["actionTypeId"] = new SelectList(_context.actiontype, "actionTypeId", "actionTypeId", action.actionTypeId);
            ViewData["tenancyId"] = new SelectList(_context.tenancy, "tenancyId", "tenancyId", action.tenancyId);
            return View(action);
        }

        // GET: Actions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.action.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }
            ViewData["actionTypeId"] = new SelectList(_context.actiontype, "actionTypeId", "actionTypeId", action.actionTypeId);
            ViewData["tenancyId"] = new SelectList(_context.tenancy, "tenancyId", "tenancyId", action.tenancyId);
            return View(action);
        }

        // POST: Actions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("actionId,actionTypeId,tenancyId,assignedUserId,actionDueDate,actionCompletedDate,updatedByUserID,updatedDT,createdByUserID,createdDT")] action action)
        {
            if (id != action.actionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(action);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!actionExists(action.actionId))
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
            ViewData["actionTypeId"] = new SelectList(_context.actiontype, "actionTypeId", "actionTypeId", action.actionTypeId);
            ViewData["tenancyId"] = new SelectList(_context.tenancy, "tenancyId", "tenancyId", action.tenancyId);
            return View(action);
        }

        // GET: Actions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _context.action
                .Include(a => a.actionType)
                .Include(a => a.tenancy)
                .FirstOrDefaultAsync(m => m.actionId == id);
            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // POST: Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var action = await _context.action.FindAsync(id);
            _context.action.Remove(action);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool actionExists(int id)
        {
            return _context.action.Any(e => e.actionId == id);
        }
    }
}
