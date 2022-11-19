using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Models;
using Microsoft.AspNetCore.Mvc;

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
            ServiceViewModel serviceViewModel = new ServiceViewModel(service);
            return View(serviceViewModel);
        }
    }
}
