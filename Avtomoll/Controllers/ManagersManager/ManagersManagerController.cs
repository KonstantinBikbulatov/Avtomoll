﻿using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomoll.Controllers.ManagersManager
{
    public class ManagersManagerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public ManagersManagerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
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
            IdentityUser user =  userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = new List<string> { "Administrator", "ContentManager", "SalesManager" };
            IdentityRole role = roleManager.FindByIdAsync(id).Result;
            ManagersManagerViewModel model = new ManagersManagerViewModel { Id = user.Id, Email = user.Email, Password= user.PasswordHash };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ManagersManagerViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = roleManager.FindByIdAsync(model.Id).Result;
                IdentityUser user = userManager.FindByIdAsync(model.Id).Result;
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.PasswordHash = model.Password;
                    role.Name = model.Role;
                        
                    var result =  userManager.UpdateAsync(user);
                    result = roleManager.UpdateAsync(role);
                   
                    return RedirectToAction("Index");
                  
                }
            }
            return View(model);
        }

        public IActionResult DeleteManagers(string id)
        {
            IdentityUser user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                IdentityResult result =  userManager.DeleteAsync(user).Result;
            }
            return RedirectToAction("Index");

           
        }
    }
}