using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenHouse.Core.Web.Services.Interfaces;
using OpenHouse.Model.Core.Model;

namespace OpenHouse.Core.Web.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personSvc;

        public PersonsController(IPersonService personSvc)
        {
            _personSvc = personSvc;
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personSvc.GetPersonAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Persons/Create
        public async Task<IActionResult> Create()
        {
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1");
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1");
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personId,firstName,middleName,surname,titleId,dateOfBirth,telephone,email,nationalityId,nextOfKinFrstName,nextOfKinSurname,nextOfKinTelephone,updatedByUserID,updatedDT,createdByUserID,createdDT")] person person)
        {
            if (ModelState.IsValid)
            {
                await _personSvc.AddPersonsAsync(person);
                return RedirectToAction(nameof(Index));
            }
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", person.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", person.titleId);
            return View(person);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personSvc.GetPersonAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", person.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", person.titleId);
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personId,firstName,middleName,surname,titleId,dateOfBirth,telephone,email,nationalityId,nextOfKinFrstName,nextOfKinSurname,nextOfKinTelephone,updatedByUserID,updatedDT,createdByUserID,createdDT")] person person)
        {
            if (id != person.personId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _personSvc.UpdatePersonsAsync(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await personExists(person.personId))
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
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", person.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", person.titleId);
            return View(person);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personSvc.GetPersonAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personSvc.DeletePersonAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> personExists(int id)
        {
            return await _personSvc.PersonExistsAsync(id);
        }
    }
}
