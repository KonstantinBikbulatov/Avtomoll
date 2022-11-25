using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Avtomoll.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<GroupService> _repositoryGroupService;
        private readonly IRepository<Service> _repositoryService;

        public AdminController(IRepository<GroupService> repositoryGroupService,
                               IRepository<Service> repositoryService
            )
        {
            _repositoryGroupService = repositoryGroupService;
            _repositoryService = repositoryService;
        }
        public IActionResult Index()
        {
            var list = _repositoryGroupService.GetList();
            return View(list);
        }

        public IActionResult EditService(long id)
        {
            var service = _repositoryService.Read(id);
            var listGroup = _repositoryGroupService.GetList();
            ServiceViewModel serviceViewModel = new ServiceViewModel
            {
                ServiceId = id,
                Name = service.Name,
                NativeCar = service.NativeCar,
                ForeignCar = service.ForeignCar,
                LeadTime = service.LeadTime,
                GroupName = service.GroupService.Name,
                ListGroups = listGroup
                .Select(
                c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.GroupServiceId.ToString()
                })
                .Where(g => g.Text != service.GroupService.Name)
                .ToList()
        };
            
            return View(serviceViewModel);
        }
        [HttpPost]
        public IActionResult EditService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group = _repositoryGroupService.Read(model.GroupServiceId);
                model.GroupService = group;
                Service service = new Service(model);
                _repositoryService.Update(service);
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }
    }
}
