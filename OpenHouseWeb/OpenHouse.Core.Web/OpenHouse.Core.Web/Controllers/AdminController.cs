using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OpenHouse.Core.Web.Areas.Identity.Data;
using OpenHouse.Core.Web.Data;
using OpenHouse.Model.Core.ViewModels;

namespace StsServerIdentity.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application", Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(IdentityContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.OrderBy(u => u.UserName).ToListAsync(); //Get all users
            List<AdminViewModel> viewModel = new List<AdminViewModel>();

            foreach(var user in users)
            {
                var userVM = new AdminViewModel //Create user viewmodal isntance
                {
                    userId = user.Id,
                    username = user.UserName,
                    firstName = user.firstName,
                    surname = user.surname,
                    isAdmin = await _userManager.IsInRoleAsync(user, "Admin"),  //Set role status values
                    isHousingUser = await _userManager.IsInRoleAsync(user, "HousingUser"),
                    isHousingManager = await _userManager.IsInRoleAsync(user, "HousingManager"),
                    isReadonly = await _userManager.IsInRoleAsync(user, "ReadOnly")
                };

                viewModel.Add(userVM); //Add user viewmodel to page model
            }

            return View(viewModel);
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new AdminViewModel
            {
                userId = user.Id,
                username = user.Email
            });
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("username,firstName,surname,telephone,isAdmin,isHousingManager,isHousingUser,isReadonly")] AdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Create new user from details
                var result = await _userManager.CreateAsync(new ApplicationUser
                {
                    Email = viewModel.username,
                    firstName = viewModel.firstName,
                    surname = viewModel.surname,
                    UserName = viewModel.username,
                    telephone = viewModel.telephone,
                });

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(viewModel.username); //Get newly created user

                    //Add selected roles for user
                    if (viewModel.isAdmin)
                        await _userManager.AddToRoleAsync(user, "Admin");

                    if (viewModel.isHousingManager)
                        await _userManager.AddToRoleAsync(user, "HousingManager");

                    if (viewModel.isHousingUser)
                        await _userManager.AddToRoleAsync(user, "HousingUser");

                    if (viewModel.isReadonly)
                    {

                        var roleResult = await _userManager.AddToRoleAsync(user, "ReadOnly");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        //GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new AdminViewModel
            {
                userId = user.Id,
                username = user.Email,
                firstName = user.firstName,
                surname = user.surname,
                telephone = user.telephone,
                isAdmin = await _userManager.IsInRoleAsync(user, "Admin"),
                isHousingUser = await _userManager.IsInRoleAsync(user, "HousingUser"),
                isHousingManager = await _userManager.IsInRoleAsync(user, "HousingMangager"),
                isReadonly = await _userManager.IsInRoleAsync(user, "ReadOnly")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("userId,username,firstName,surname,telephone,isAdmin,isHousingManager,isHousingUser,isReadonly")] AdminViewModel viewModel)
        {
            if (id != viewModel.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id); //Get existing user

                    //Update user values
                    user.Email = viewModel.username;
                    user.firstName = viewModel.firstName;
                    user.surname = viewModel.surname;
                    user.UserName = viewModel.username;
                    user.telephone = viewModel.telephone;

                    //Add selected roles for user
                    bool userAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                    if (viewModel.isAdmin && !userAdmin)
                        await _userManager.AddToRoleAsync(user, "Admin");
                    else if (!viewModel.isAdmin && userAdmin)
                        await _userManager.RemoveFromRoleAsync(user, "Admin");

                    bool userHousingManager = await _userManager.IsInRoleAsync(user, "HousingManager");

                    if (viewModel.isHousingManager && !userHousingManager)
                        await _userManager.AddToRoleAsync(user, "HousingManager");
                    else if (!viewModel.isHousingManager && userHousingManager)
                        await _userManager.RemoveFromRoleAsync(user, "HousingManager");

                    bool userHousingUser = await _userManager.IsInRoleAsync(user, "HousingUser");

                    if (viewModel.isHousingUser && !userHousingUser)
                        await _userManager.AddToRoleAsync(user, "HousingUser");
                    else if (!viewModel.isHousingUser && userHousingUser)
                        await _userManager.RemoveFromRoleAsync(user, "HousingUser");

                    bool userReadOnly = await _userManager.IsInRoleAsync(user, "ReadOnly");

                    if (viewModel.isReadonly && !userReadOnly)
                        await _userManager.AddToRoleAsync(user, "ReadOnly");
                    else if (!viewModel.isReadonly && userReadOnly)
                        await _userManager.RemoveFromRoleAsync(user, "ReadOnly");
                    //Save user to database
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminViewModelExists(viewModel.username))
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
            return View(viewModel);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new AdminViewModel
            {
                userId = user.Id,
                username = user.Email,
                firstName = user.firstName,
                surname = user.surname
            });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

        private bool AdminViewModelExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }
    }
}

