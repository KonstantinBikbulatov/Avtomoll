using Avtomoll.Abstract;
using Avtomoll.DataAccessLayer;
using Avtomoll.Domains;
using Avtomoll.ViewModel.ReceptionModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Avtomoll.Controllers.Manager
{
    public class ReceptionController : Controller
    {
        private int _receptionQuantityPerPage = 7;

        private int countDate = 7;
        private readonly IRepository<ServiceHistory> _repositoryServiceHistory;
        private readonly IRepository<CarService> _repositoryCarservice;
        private readonly ClientServiceSqlRepository _repositoryClienService;

        public ReceptionController(IRepository<ServiceHistory> repositoryServiceHistory, 
            IRepository<CarService> repositoryCarservice,
            ClientServiceSqlRepository repositoryClienService)
        {
            _repositoryServiceHistory = repositoryServiceHistory;
            _repositoryCarservice = repositoryCarservice;
            _repositoryClienService = repositoryClienService;
        }

        [HttpGet("manager/reception/{page?}")]
        public IActionResult index(int page, string carService = "")
        {
            ListReseptionViewModel model = new ListReseptionViewModel();
            model.NameModel = "reception";
            model = GetModel(page, model, carService);
            return View(model);
        }

        public ListReseptionViewModel GetModel(int page, ListReseptionViewModel model, string carService)
        {
            if (page == 0)
            {
                page = 1;
            }

            List<DateTime> dates = new List<DateTime>();

            model.ReceptionForPage = new List<ReceptionViewModel>();

            for (int i = 0; i < countDate; i++)
            {
                DateTime dateTime = new DateTime();
                dateTime.AddDays(i);
                dates.Add(dateTime);
            }

            CarService carservice = new CarService();

            if (carService == "")
            {
                carservice = _repositoryCarservice.Read(1);
            }
            else
            {
                carservice = _repositoryCarservice.FindByName(carService);
            }

            var timeJob = carservice.ClosingTime.Add(-carservice.OpeningTime);

            int result = (timeJob.Hours * 2) + timeJob.Minutes / 30;

            var openTime = new DateTime()
            .AddHours(carservice.OpeningTime.Hours)
            .AddMinutes(carservice.OpeningTime.Minutes);

            var date = DateTime.Now;

            date = date.AddDays((page == 1 ? 0 : page - 1) * _receptionQuantityPerPage);

            for (int i = 0; i < _receptionQuantityPerPage; i++)
            {
                //day += i;
                var reception = new ReceptionViewModel(carservice.CarsCapacity, result);
                var listService = new List<ServiceHistory>();

                if(carService == "")
                {
                    var firstCarservice = _repositoryCarservice.GetList().FirstOrDefault();
                    listService = _repositoryServiceHistory.GetList().Where(r => r.VisitTime.Day == date.Day && r.CarService.Address == firstCarservice.Address).ToList();
                    carService = firstCarservice.Address;
                }
                else
                {
                    listService = _repositoryServiceHistory.GetList().Where(r => r.VisitTime.Day == date.Day && r.CarService.Address == carService).ToList();
                }

                HttpContext.Session.SetString("carservice", carService);

                reception.Date = date;
                date = date.AddDays(1);

                foreach (var item in listService)
                {
                    if (item.PlaceInCarservice != null)
                    {
                        var interval = (item.VisitTime.Hour - carservice.OpeningTime.Hours) * 2;
                        if (item.VisitTime.Minute >= 30)
                        {
                            interval += 1;
                        }
                        reception.TimeReception[(int)item.PlaceInCarservice, interval] = new DataReception();
                        reception.TimeReception[(int)item.PlaceInCarservice, interval].ServiceHistoryId = item.ServiceHistoryId;
                        reception.TimeReception[(int)item.PlaceInCarservice, interval].Time = item.VisitTime;
                        reception.TimeReception[(int)item.PlaceInCarservice, interval].Duration = _repositoryClienService.AllServicesFromLead(item.ServiceHistoryId).Select(s => s.LeadTimeInMinuts).Sum();
                    }
                }
                reception.TimeOpenCarservice = openTime;
                model.ReceptionForPage.Add(reception);
            }

            model.ActivePage = page == 0 ? 1 : page;
            model.PagesQuantity = 7;
            ViewBag.carService = carService;
            return model;
        }
    }
}