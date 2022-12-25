using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Avtomoll.Heplers;
using Avtomoll.ViewModel;
using Avtomoll.ViewModel.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Avtomoll.Controllers.Client
{
    public class ServiceController : Controller
    {
        private IRepository<GroupService> groupService;
        private readonly IRepository<CarService> carsrvice;
        private IRepository<Service> services;
        private IRepository<ServiceHistory> servicesHistory;
        private ClientServiceSqlRepository ClientService;
        public ServiceController(
            IRepository<Service> services,
            IRepository<ServiceHistory> servicesHistory,
            IRepository<GroupService> groupService,
            IRepository<CarService> carservice,
            ClientServiceSqlRepository clientService)
        {
            this.services = services;
            this.servicesHistory = servicesHistory;
            this.groupService = groupService;
            this.carsrvice = carservice;
            ClientService = clientService;
        }
        [HttpPost]
        public IActionResult MakeOrder(ServiceOrderViewModel model)
        {
            ServiceHistory order = new ServiceHistory()
            {
                CarBrand = model.ServiceHistory.CarBrand,
                Status = HelperLeadStatus.Awaiting,
                NameClient = model.ServiceHistory.ClientName,
                TypeCar = model.ServiceHistory.TypeCar,
                PhoneClient = model.ServiceHistory.ClientPhone,
                PriceService = model.ServiceHistory.PriceService,
                OrderTime = DateTime.Now,
                VisitTime = model.ServiceHistory.VisitTime
            };
            servicesHistory.Create(order);
            long lastId = servicesHistory.GetList().Last().ServiceHistoryId;
            return RedirectToAction("AddServicesList", new { LeadId = lastId });
        }
        public IActionResult MakeOrder()
        {
            ServiceOrderViewModel model = new ServiceOrderViewModel()
            {
                ServiceHistory = new ServiceHistoryViewModel(),
                CarTypeForeign = HelperLeadStatus.CarTypeForeign,
                CarTypeNative = HelperLeadStatus.CarTypeNative,
                ListCarservice = carsrvice.GetList()
                .Select(
                    c => new SelectListItem()
                    {
                        Text = c.Address,
                        Value = c.CarServiceId.ToString()
                    })
                .ToList()
            };
            return View(model);
        }
        public IActionResult AddServicesList(long LeadId)
        {
            ViewBag.id = LeadId;
            return View(groupService.GetList());
        }
        public IActionResult Details(long LeadId)
        {
            var order = servicesHistory.Read(LeadId);
            ServiceHistoryViewModel model = new ServiceHistoryViewModel(order);
            model.Services = ClientService.AllServicesFromLead(LeadId);

            return View(model);
        }
        public IActionResult AddService(long LeadId, long ServiceId)
        {
            var order = servicesHistory.Read(LeadId);
            var service = services.Read(ServiceId);
            ClientService.Create(order, service);
            servicesHistory.Update(order);
            return RedirectToAction("Details", new { LeadId = LeadId });
        }
    }
}
