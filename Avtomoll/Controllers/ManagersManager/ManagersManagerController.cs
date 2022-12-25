using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Avtomoll.Controllers.ManagersManager
{
    public class ManagersManagerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;


        public ManagersManagerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            var model = userManager.Users.ToList()
                                       .Select(s => new ManagersManagerViewModel(s));

            return View(model);
        }

       
        public IActionResult CreateManager()
        {
            ManagersManagerViewModel model = new ManagersManagerViewModel();
            ViewBag.Roles = new List<string> { "Administrator", "ContentManager", "SalesManager" };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateManager(ManagersManagerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manager = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManager.CreateAsync(manager, model.Password).Result;

                if (userResult.Succeeded)
                {
                    userResult = userManager.AddToRoleAsync(manager, model.Role).Result;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        public IActionResult Edit(string id)
        {
            IdentityUser user = userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = new List<string> { "Administrator", "ContentManager", "SalesManager" };
            ManagersManagerViewModel model = new ManagersManagerViewModel(user);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ManagersManagerViewModel model, string id, IdentityUser identity)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var roles = userManager.GetRolesAsync(identity).Result;

            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                };
                IdentityResult userResult = userManager.UpdateAsync(identityUser).Result;

                if (userResult.Succeeded)
                {
                    userResult = userManager.AddToRoleAsync(identityUser, model.Role).Result;
                }

                



                    return RedirectToAction("Index");

                
            }
            return View(model);
        }

        public IActionResult DeleteManagers(string id)
        {
            IdentityUser user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                IdentityResult result = userManager.DeleteAsync(user).Result;
            }
            return RedirectToAction("Index");


        }
    }
}
