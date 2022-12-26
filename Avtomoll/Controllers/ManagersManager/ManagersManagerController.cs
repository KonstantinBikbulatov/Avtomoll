using Avtomoll.DataAccessLayer;
using Avtomoll.Migrations;
using Avtomoll.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Avtomoll.Controllers.ManagersManager
{
    public class ManagersManagerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;


        public ManagersManagerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
        public IActionResult Index(ManagersManagerViewModel model)
        {

            var userRole = _context.UserRoles.Where(role => role.UserId == model.Id).FirstOrDefault();
            var role = _context.Roles.Where(role => role.Id == userRole.RoleId).ToList();

            var model1 = userManager.Users.ToList()
                                       .Select(s => new ManagersManagerViewModel(s));

            return View(role);
        }


        public IActionResult CreateManager()
        {
            ManagersManagerViewModel model = new ManagersManagerViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateManager(ManagersManagerViewModel model)
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

        public IActionResult Edit(string id)
        {
            IdentityUser user = userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            ManagersManagerViewModel model = new ManagersManagerViewModel(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManagersManagerViewModel model)
        {

            var userRole = _context.UserRoles.Where(role => role.UserId == model.Id).FirstOrDefault();
            var role = _context.Roles.Where(role => role.Id == userRole.RoleId).FirstOrDefault();

            IdentityUser user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                await userManager.RemoveFromRoleAsync(user, role.Name);
                await userManager.AddToRoleAsync(user, model.Role);

                user.Email = model.Email;
                user.UserName = model.Email;

                await userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
             

                await _signInManager.RefreshSignInAsync(user);

                await userManager.UpdateAsync(user);

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
