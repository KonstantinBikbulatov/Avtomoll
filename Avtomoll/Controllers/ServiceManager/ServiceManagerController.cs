using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Avtomoll.Heplers;
using Avtomoll.ViewModel.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avtomoll.Controllers.ServiceManager
{
    public class ServiceManagerController : Controller
    {
        private readonly ClientServiceSqlRepository leadServices;

        public ServiceManagerController(IRepository<ServiceHistory> repository, 
            IRepository<Service> services, 
            IRepository<GroupService> repositoryGroupService,
            ClientServiceSqlRepository leadServices)
        {
            Repository = repository;
            Services = services;
            RepositoryGroupService = repositoryGroupService;
            this.leadServices = leadServices;
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

            if (carService != "")
            {
                leads = leads.Where(s => s.CarService.Address == carService);
            }

            if(status != "")
            {
                leads = leads.Where(s => s.Status == status);
            }

            var viewModel = new LeadsListViewModel(leads)
            {
                leads = leads
            };
            return View(viewModel);
        }

        public IActionResult Edit(long LeadId)
        {
            var services = leadServices.AllServicesFromLead(LeadId);

            var lead = new ServiceHistoryViewModel(Repository.Read(LeadId));
            lead.Services = services;

            var viewModel = new EditLeadViewModel(lead);
            
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
            var model = new ServiceHistoryViewModel(Repository.Read(LeadId));
            model.Services = leadServices.AllServicesFromLead(LeadId);
            return View(model);
        }

        public IActionResult CancelService(long ServiceId, long LeadId)
        {
            leadServices.Cancel(ServiceId, LeadId);

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

            leadServices.Create(lead, service);

            return RedirectToAction("Details", new { LeadId = LeadId });
        }

    }
}
