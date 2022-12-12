using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
