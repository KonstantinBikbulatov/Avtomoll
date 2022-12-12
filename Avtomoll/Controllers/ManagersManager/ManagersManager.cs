﻿using Avtomoll.Abstract;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace Avtomoll.Controllers.ManagersManager
{
    public class ManagersManager : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public ManagersManager(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
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
                IdentityUser manager = new IdentityUser(model.Login);

                IdentityResult userResult = userManager.CreateAsync(manager, model.Password).Result;

                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRoleAsync(manager, model.Role).Result;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
