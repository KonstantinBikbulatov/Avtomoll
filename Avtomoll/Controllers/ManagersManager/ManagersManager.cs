using Avtomoll.Abstract;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult Create()
        {
            ManagersManagerViewModel model = new ManagersManagerViewModel
            {
                Roles = new List<string> { "Administrator", "ContentManager", "SalesManager" },
                Login = "",
                Password = "",
                Role = ""
            };
            return View(model);
        }
    }
}
