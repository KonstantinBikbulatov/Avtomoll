﻿using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Heplers;
using Avtomoll.ViewModel;
using Avtomoll.ViewModel.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Avtomoll.Controllers.Client
{
    public class ServiceController : Controller
    {
        private IRepository<GroupService> groupService;
        private IRepository<Service> services;
        private IRepository<ServiceHistory> servicesHistory;
        public ServiceController(
            IRepository<Service> services, 
            IRepository<ServiceHistory> servicesHistory,
            IRepository<GroupService> groupService)
        {
            this.services = services;
            this.servicesHistory = servicesHistory;
            this.groupService = groupService;
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
            return RedirectToAction("AddServicesList", new { id = lastId });
        }
        public IActionResult MakeOrder()
        {
            ServiceOrderViewModel model = new ServiceOrderViewModel()
            {
                ServiceHistory = new ServiceHistoryViewModel(),
                CarTypeForeign = HelperLeadStatus.CarTypeForeign,
                CarTypeNative = HelperLeadStatus.CarTypeNative
            };
            return View(model);
        }
        public IActionResult AddServicesList(long id)
        {
            ViewBag.id = id;
            return View(groupService.GetList());
        }
        public IActionResult Details(long id)
        {
            var order = servicesHistory.Read(id);
            ServiceHistoryViewModel model = new ServiceHistoryViewModel(order);
            
            return View(model);
        }
        public IActionResult AddService(long LeadId, long ServiceId)
        {
            var order = servicesHistory.Read(LeadId);
            var service = services.Read(ServiceId);
            order.AddService(service);
            servicesHistory.Update(order);
            return RedirectToAction("Details", new { id = LeadId });
        }        
    }
}
