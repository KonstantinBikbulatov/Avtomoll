using Avtomoll.Abstract;
using Avtomoll.Models;
using Microsoft.AspNetCore.Mvc;
using Avtomoll.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Avtomoll.Controllers
{
    public class AdminPanelManagersController : Controller
    {
        private readonly IRepository<Manager> _repository;

        // 3) Инъекция зависимостей
        public AdminPanelManagersController(IRepository<Manager> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var model = _repository.GetList().
               Select(s => new ManagerViewModel(s));

            return View(model);
        }

        public IActionResult Create(long id)
        {
            var manager = _repository.Read(id);

            return View(manager);
        }

        
        [HttpPost]
        public IActionResult Create(ManagerViewModel model)
        {
            // валидация данных на сервере (на клиенте недостаточно безопасно)
            if (ModelState.IsValid)
            {
                Manager manager = new Manager()
                {
                    ManagerId = model.ManagerId,
                    RoleManager = model.RoleManager,
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    PasswordConfirmation= model.PasswordConfirmation,
                };

                _repository.Create(manager);

                return RedirectToAction("List", "AdminPanelManagers");
            }

            return View(model);
        }

        public IActionResult EditManager(long id)
        {
            var manager = _repository.Read(id);

            return View(manager);
        }

        [HttpPost]
        public IActionResult EditManager(Manager model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                return RedirectToAction("List", "AdminPanelManagers");
            }

            return View();
        }

        public IActionResult DeleteManager(long id)
        {
            _repository.Delete(id);

            return RedirectToAction("List", "AdminPanelManagers");
        }
    }
}
