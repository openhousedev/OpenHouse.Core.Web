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
using OpenHouse.Core.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace OpenHouse.Core.Web.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMapper _mapper;
        private readonly IPersonService _personSvc;
        private readonly UserManager<User> _userManager;

        public PersonsController(IPersonService personSvc, UserManager<User> userManager)
        {
            //Assign services
            _personSvc = personSvc;
            _userManager = userManager;

            //AutoMapper mapping config
            _mapperConfig = new MapperConfiguration(cfg => { 
                cfg.CreateMap<person, PersonViewModel>(); 
                cfg.CreateMap<PersonViewModel, person>(); 
            });

            //Create mapper instance
            _mapper = _mapperConfig.CreateMapper();
        }

        // GET Person/_PersonSearch
        public async Task<IActionResult> _PersonSearch(string searchString, string displayType)
        {
            var persons = await _personSvc.GetPersonsAsync(searchString);
            ViewBag.DisplayType = displayType;

            return PartialView(persons);
        }

        // GET: Person/_PersonSelector
        public async Task<IActionResult> _PersonSelector()
        {
            return await Task.Run(() => View());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PersonViewModel personVM = new PersonViewModel();

            var person = await _personSvc.GetPersonAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            personVM = _mapper.Map<PersonViewModel>(person);

            User createByUser = await _userManager.FindByIdAsync(personVM.createdByUserID);
            personVM.createdByUsername = createByUser.UserName;

            User updatedByUser = await _userManager.FindByIdAsync(personVM.updatedByUserID);
            personVM.updatedByUsername = updatedByUser.UserName;

            return View(personVM);
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
        public async Task<IActionResult> Create([Bind("personId,firstName,middleName,surname,titleId,dateOfBirth,telephone,email,nationalityId,nextOfKinFrstName,nextOfKinSurname,nextOfKinTelephone")] PersonViewModel personVM)
        {
            if (ModelState.IsValid)
            {
                DateTime recordDT = DateTime.Now;
                var _person = _mapper.Map<person>(personVM); //Map viewmodel to entity class

                var user = await _userManager.GetUserAsync(HttpContext.User); //Get logged in user
                
                //Set created by & updated by values for record
                _person.updatedByUserID = user.Id;
                _person.updatedDT = recordDT;
                _person.createdByUserID = user.Id;
                _person.createdDT = recordDT;

                int newPersonId = await _personSvc.AddPersonsAsync(_person); //Save new person to database and return ID

                return RedirectToAction("Details", new { @id = newPersonId }); //Redirect to details screen for new person created
            }
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", personVM.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", personVM.titleId);
            return View(personVM);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PersonViewModel personVM = new PersonViewModel();
            var person = await _personSvc.GetPersonAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            personVM = _mapper.Map<PersonViewModel>(person); //Map person object to ViewModel

            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", person.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", person.titleId);
            return View(personVM);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personId,firstName,middleName,surname,titleId,dateOfBirth,telephone,email,nationalityId,nextOfKinFrstName,nextOfKinSurname,nextOfKinTelephone,updatedByUserID,updatedDT,createdByUserID,createdDT")] PersonViewModel personVM)
        {
            if (id != personVM.personId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                person _person = null;

                try
                {
                    //_person = await _personSvc.GetPersonAsync(personVM.personId); //Get existing person value
                    _person = _mapper.Map<person>(personVM); //Map amended ViewModel to existing person object
                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    _person.updatedByUserID = user.Id;
                    _person.updatedDT = DateTime.Now;

                    await _personSvc.UpdatePersonsAsync(_person); //Update person
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await personExists(_person.personId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { @id = _person.personId });
            }
            ViewData["nationalityId"] = new SelectList(await _personSvc.GetNationalitiesAsync(), "nationalityId", "nationality1", personVM.nationalityId);
            ViewData["titleId"] = new SelectList(await _personSvc.GetTitlesAsync(), "titleId", "title1", personVM.titleId);
            return View(personVM);
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
