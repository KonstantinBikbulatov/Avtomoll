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
        private readonly IRepository<ManagerViewModel> _repository;

        // 3) Инъекция зависимостей
        public AdminPanelManagersController(IRepository<ManagerViewModel> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var manager = _repository.GetList();
            return View(manager);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Home / Create
        [HttpPost]
        public IActionResult Create(ManagerViewModel model)
        {
            // валидация данных на сервере (на клиенте недостаточно безопасно)
            if (ModelState.IsValid)
            {
                _repository.Create(model);
                return RedirectToAction("List", "AdminPanelManagers");
            }

            return View(model);
        }

        public IActionResult EditManager(long id)
        {
            var student = _repository.Read(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult EditManager(ManagerViewModel model)
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
