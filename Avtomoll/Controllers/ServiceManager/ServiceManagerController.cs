using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Heplers;
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
            ViewBag.status = status;
            ViewBag.carService = carService;

            IEnumerable<ServiceHistoryViewModel> leads = Repository.
                GetList().Select(s => new ServiceHistoryViewModel(s));

            var sortedleads = leads.Where(s => carService == "" || s.CarService.Address == carService);
            sortedleads = sortedleads.Where(s => status == "" || s.Status == status);


            var viewModel = new LeadsListViewModel(leads)
            {
                leads = sortedleads
            };
            return View(viewModel);
        }


        public IActionResult Edit(long LeadId)
        {
            var viewModel = new EditLeadViewModel(new ServiceHistoryViewModel(Repository.Read(LeadId)));

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ServiceHistoryViewModel model)
        {
            var lead = Repository.Read(model.id);
            lead.CarBrand = model.CarBrand;
            lead.NameClient = model.ClientName;
            lead.PhoneClient = model.ClientPhone;
            lead.Status = model.Status;
            lead.VisitTime = model.VisitTime;
            lead.PriceService = model.PriceService;
            lead.TypeCar = model.TypeCar;

            Repository.Update(lead);

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

            return RedirectToAction("Details", new { LeadId = LeadId });
        }

    }
}
