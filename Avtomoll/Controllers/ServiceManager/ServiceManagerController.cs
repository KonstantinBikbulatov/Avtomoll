using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.ViewModel.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.Controllers.ServiceManager
{
    public class ServiceManagerController : Controller
    {
        
        public ServiceManagerController(IRepository<ServiceHistory> repository, IRepository<Service> services, IRepository<GroupService> repositoryGroupService)
        {
            Repository = repository;
            Services = services;
            RepositoryGroupService = repositoryGroupService;
        }

        private IRepository<ServiceHistory> Repository { get; set; }
        public IRepository<Service> Services { get; }
        public IRepository<GroupService> RepositoryGroupService { get; }

        public IActionResult Index(string status = "", string carService = "")
        {
            IEnumerable<ServiceHistoryViewModel> model = Repository.
                GetList().
                Where(s => status == "" || s.Status == status).
                Select(s => new ServiceHistoryViewModel(s));

            model = model.Where(s => carService == "" || s.CarService.Address == carService);
            return View(model);
        }


        public IActionResult Edit(long LeadId)
        {
            return View(new ServiceHistoryViewModel(Repository.Read(LeadId)));
        }

        [HttpPost]
        public IActionResult Edit(ServiceHistoryViewModel model)
        {
            ServiceHistory service = new ServiceHistory()
            {
                ServiceHistoryId = model.id,
                CarBrand = model.CarBrand,
                NameClient = model.ClientName,
                PhoneClient = model.ClientPhone,
                Status = model.Status,
                VisitTime = model.VisitTime,
                PriceService = model.PriceService,
                TypeCar = model.TypeCar,
            };
            Repository.Update(service);

             return RedirectToAction("Details", new { LeadId = model.id });
        }

        public IActionResult Details(long LeadId)
        {
            return View(new ServiceHistoryViewModel(Repository.Read(LeadId)));
        }

        public IActionResult CancelService(long ServiceId, long LeadId)
        {
            var lead = Repository.Read(LeadId);

            lead.DeleteService(ServiceId);
            Repository.Update(lead);

            return RedirectToAction("Details", new { LeadId = LeadId });
        }


        public IActionResult AddServicesList(long LeadId)
        {
            ViewBag.LeadId = LeadId;
            return View(RepositoryGroupService.GetList());
        }

        public IActionResult AddService(long LeadId, long ServiceId)
        {
            var lead = Repository.Read(LeadId);
            var service = Services.Read(ServiceId);
            lead.AddService(service);
            Repository.Update(lead);

            return RedirectToAction("Details", new {LeadId = LeadId });
        }

    }
}
