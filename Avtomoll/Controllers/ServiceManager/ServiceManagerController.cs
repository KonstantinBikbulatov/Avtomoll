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
        
        public ServiceManagerController(IRepository<ServiceHistory> repository, IRepository<Service> services)
        {
            Repository = repository;
            Services = services;
        }

        private IRepository<ServiceHistory> Repository { get; set; }
        public IRepository<Service> Services { get; }

        public IActionResult Index()
        {
            return View(Repository.GetList().Select(s => new ServiceHistoryViewModel(s)));
        }


        public IActionResult Edit(long id)
        {
            return View(new ServiceHistoryViewModel(Repository.Read(id)));
        }

        [HttpPost]
        public IActionResult Edit(ServiceHistoryViewModel model)
        {
            ServiceHistory service = new ServiceHistory()
            {
                CarBrand = model.CarBrand,
                NameClient = model.ClientName,
                PhoneClient = model.ClientPhone,
                Status = model.Status,
                VisitTime = model.VisitTime,
                TypeCar = model.TypeCar,
            };
            Repository.Update(service);

            return RedirectToAction("Details", model.id);
        }

        public IActionResult Details(long id)
        {
            return View(new ServiceHistoryViewModel(Repository.Read(id)));
        }

        public IActionResult CancelService(long ServiceId, long LeadId)
        {
            var lead = Repository.Read(LeadId);

            lead.DeleteService(ServiceId);

            return RedirectToAction("Details", LeadId);
        }


    }
}
